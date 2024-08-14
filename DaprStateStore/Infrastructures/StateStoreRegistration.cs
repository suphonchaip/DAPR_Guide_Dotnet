using DaprStateStore.Core;
using ShareKernel.Core.Interfaces;
using ShareKernel.Models;

namespace DaprStateStore.Infrastructures
{
    public static class StateStoreRegistration
    {
        public static IServiceCollection AddStateStore(this IServiceCollection services)
        {
            services.AddScoped<IStateStore<Order>, OrderStateStore>();

            return services;
        }
    }
}
