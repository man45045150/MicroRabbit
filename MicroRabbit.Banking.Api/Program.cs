using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(
                    new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json",false)
                    .AddJsonFile("appsettings.Development.json",false)
                    .AddCommandLine(args)
                    .Build()
                )
                .UseStartup<Startup>()
                .Build();
                // .ConfigureAppConfiguration((hostingContext, config) =>
                // {
                //     config.SetBasePath(Directory.GetCurrentDirectory());
                //     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                //     config.AddCommandLine(args);                    
                // })
                // .UseStartup<Startup>();
    }
}
