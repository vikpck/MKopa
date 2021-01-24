using System;
using Microsoft.Extensions.DependencyInjection;
using MKopaSolar.Interfaces;

namespace MKopaSolar.IoC
{
    public static class ClientsRegistrator
    {
        public static IServiceCollection AddClients(this IServiceCollection services)
        {

            //This is were the httpclient being injected in the SMS client 
            //it uses the factory client which provide resilience
            // retry policy and circuit breaker policy need to be set based on the SLA 
            //and 3rd party agreement.
            //correlationIdhandler and logginghandler should be added here by implementing DelegateHandler

            /*services.AddHttpClient<ISmsClient, SmsClient>(client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                })
            //With retry policy we need to log errors after all retries and warning on every failed retry
            //to keep logs clean and not to fill it with un-necessary errors
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy())
                .AddHttpMessageHandler<CorrelationIdHandler>().SetHandlerLifetime(TimeSpan.FromHours(1))
                .AddHttpMessageHandler<LoggingHandler>().SetHandlerLifetime(TimeSpan.FromHours(1)); */

            return services;
        }
    }
}
