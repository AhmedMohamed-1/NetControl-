using Microsoft.EntityFrameworkCore;
using Code_Generator_Web_App.Models;

namespace Code_Generator_Web_App
{
    public class CodeExpirationService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CodeExpirationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<GeneratedCodesContext>(); // Replace with your DbContext

                var now = DateTime.UtcNow;

                var activeCodes = await dbContext.Codes
                    .Where(c => c.Status == 1)
                    .ToListAsync(stoppingToken);

                foreach (var code in activeCodes)
                {
                    if (IsCodeExpired(code.StartTime, code.Duration))
                    {
                        // Code has expired, update the state
                        code.Status = 2;
                        Console.WriteLine($"⛔ Code {code.TheCode} has expired.");
                    }
                }
                await dbContext.SaveChangesAsync(stoppingToken);

                // Default delay (e.g., 30 seconds) before checking again
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }

        private bool IsCodeExpired(DateTime startTime, int duration)
        {
            TimeSpan timeLeft = (startTime.AddMinutes(duration)) - DateTime.Now;

            return timeLeft.TotalSeconds <= 0;  // Expired if the total seconds are less than or equal to 0
        }

    }
}
