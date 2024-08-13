using DaprStateStore.Core;
using DaprStateStore.Core.Interfaces;
using DaprStateStore.Models;

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
