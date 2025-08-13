﻿using ServiceMesh.Services.EmailAPI.Messaging;

namespace ServiceMesh.Services.EmailAPI.Extensions
{
    public static class ApplicationBuilderExtension
    {
        private static IAzureServiceBusConsumer ServiceBusConsumer { get; set; }
        public static IApplicationBuilder UseAzureServiceBusConsumer(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IAzureServiceBusConsumer>();
            var hostApplicationLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            hostApplicationLifetime.ApplicationStarted.Register(OnStart);
            hostApplicationLifetime.ApplicationStopping.Register(OnStop);
            return app;
        }

        private static void OnStart()
        {
            ServiceBusConsumer.Start();
        }

        private static void OnStop()
        {
            ServiceBusConsumer.Stop();
        }
    }
}
