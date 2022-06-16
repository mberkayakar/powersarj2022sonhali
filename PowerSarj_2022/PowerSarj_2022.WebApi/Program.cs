using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerSarj_2022.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //var logger = host.Services.GetRequiredService<ILogger<Program>>();



            //try
            //{
            //    logger.LogTrace(DateTime.Now.ToString() + "\t \t " + "Uygulama Deploye ediliyor");
                host.Run();
                //logger.LogTrace(DateTime.Now.ToString() + " \t \t" + "PowerSarj uygulaması Başarı ile ayaga kaldırıldı");
            //}
            //catch (ArgumentException ex)
            //{
            //    logger.LogCritical(DateTime.Now.ToString() + " \t \t" + "Program Yürütme Esnasında Kritik bir seviyede hata gerçekleşti : "+ex.Message);
            //}


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                //    .ConfigureLogging(logger =>
                //    {
                //        logger.ClearProviders(); // built in olarak gelen logger  eventini kaldırarak kendi kişileştirmemiz göre loglama yapmamızı sağlayabilmek amacı ile eklenmiş olan bir eventtir. 
                        
                    }
                );
                //})
                //.UseNLog();
    }
}
