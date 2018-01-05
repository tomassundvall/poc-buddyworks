using System.Net;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
                .UseKestrel(options => 
                {
                    options.Listen(IPAddress.Loopback, 5000);
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile("version.json", optional: true, reloadOnChange: false);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, log) =>
                {
                    log.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    log.AddConsole();
                    log.AddDebug();
                })
                .UseStartup<Startup>()
                .Build();

            webHost.Run();
        }
    }
}