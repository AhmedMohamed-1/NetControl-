using Code_Generator_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Code_Generator_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;
        private static readonly char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly Random random = new();
        private readonly GeneratedCodesContext _dbContext;  // DbContext to be injected

        // Constructor to inject DbContext along with other dependencies
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache, GeneratedCodesContext dbContext)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (_memoryCache.TryGetValue("LastCode", out Code cachedModel) && cachedModel != null)
            {
                // Calculate the time passed since code generation
                TimeSpan timePassed = DateTime.Now - cachedModel.StartTime;
                int remainingTime = cachedModel.Duration - (int)timePassed.TotalMinutes;

                // If the remaining time is greater than 0, return the cached model
                if (remainingTime > 0)
                {
                    cachedModel.Duration = remainingTime; // Update the remaining time in the cached model
                    return View(cachedModel); // Show the cached code with updated remaining time
                }
                else
                {
                    // If the time has expired, invalidate the cache (or refresh the code)
                    _memoryCache.Remove("LastCode");
                }
            }

            return View(new Code()); // If no valid cache exists, return the empty view
        }

        [HttpPost]
        public IActionResult GenerateCode(Code request)
        {
            if (request.Duration < 5 || request.Duration > 1440)
            {
                ModelState.AddModelError("Duration", "Duration must be between 5 and 1440 minutes.");
                return View("Index", new Code());
            }

            var startTime = DateTime.Now;
            var encryptedCode = new string(Enumerable.Range(0, 8).Select(_ => chars[random.Next(chars.Length)]).ToArray());

            var model = new Code
            {
                Duration = request.Duration,
                TheCode = encryptedCode,
                StartTime = startTime,
                Status = 1
            };

            _dbContext.Codes.Add(model);
            _dbContext.SaveChanges();


            // Cache the model with expiration
            _memoryCache.Set("LastCode", model, TimeSpan.FromMinutes(request.Duration));

            // Redirect to avoid form resubmission warning
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
