using System.IO.Pipes;
using System.Management;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DisableEthernet
{
    [SupportedOSPlatform("windows")]
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;  // Instance member
        private string EthernetName = "Ethernet 6"; // Change this to your Ethernet name if needed

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service Started ........");
            Console.WriteLine("Service Started................");
            try
            {
                _logger.LogInformation("Disabling Ethernet...");
                Console.WriteLine("Disabling Ethernet ...........");
                Disable();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during service execution: {ex.Message}");
            }

            Console.WriteLine("Ethernet Disabled Successfully .............");
            return Task.CompletedTask;
        }

        private void Disable()
        {
            try
            {
                _logger.LogInformation("Attempting to disable Ethernet...");
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string? name = obj["NetConnectionID"]?.ToString();

                        if (name != null && name.StartsWith("Ethernet") && name == EthernetName)
                        {
                            var result = obj.InvokeMethod("Disable", null);
                            _logger.LogInformation($"Successfully disabled {name}: {result}");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error disabling Ethernet: {ex.Message}");
            }
        }

    }
}
