using Serilog;
using System;
using System.IO;
using System.Text;
using System.Web.Http;
using WebApiLogger.App_Start;

namespace WebApiLogger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //create serilog logger
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ApiLog\.txt");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(new CustomCompactJsonFormatter(), logPath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    encoding: Encoding.UTF8)
                .CreateLogger();

            // Web API 設定和服務
            config.EnableCors();

            config.MessageHandlers.Add(new LogHandler());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
