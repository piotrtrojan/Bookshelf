using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Bookshelf.WebHost
{
    /// <summary>
    /// Main Application class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        public static void Main()
        {
            CreateHostBuilder(null).Build().Run();
        }

        /// <summary>
        /// Prepares IHostBuilder object using Startup configuration.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
