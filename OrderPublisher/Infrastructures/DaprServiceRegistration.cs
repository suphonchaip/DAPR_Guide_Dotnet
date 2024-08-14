using OrderPublisher.Services;
using ShareKernel.Core.Interfaces;
using ShareKernel.Models;

namespace OrderPublisher.Infrastructures
{
    public static class DaprServiceRegistration
    {
        public static IServiceCollection AddDaprPubSub(this IServiceCollection services)
        {
            services.AddScoped<OrderPublisherService>();

            return services;
        }
    }
}
