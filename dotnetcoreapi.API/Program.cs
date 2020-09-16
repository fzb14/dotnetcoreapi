using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcoreapi.API.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace dotnetcoreapi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Info("Application starts....");
                var host = CreateHostBuilder(args).Build();
                using(var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetService<CityInfoContext>();
                        //for demo only
                        context.Database.EnsureDeleted();
                        context.Database.Migrate();
                    }
                    catch(Exception ex)
                    {
                        logger.Error(ex, "Exception happened while migrate database.");
                    }
                }
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application stops as Exception happened...");
                throw;

            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseNLog();
                });
    }
}
