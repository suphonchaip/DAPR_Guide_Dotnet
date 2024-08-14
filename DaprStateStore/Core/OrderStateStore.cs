using Dapr.Client;
using ShareKernel.Core.Interfaces;
using ShareKernel.Models;
using System.Text.Json;

namespace DaprStateStore.Core
{
    public class OrderStateStore : IStateStore<Order>
    {
        private readonly DaprClient _client;
        private static string STORE_NAME = "statestore";

        public OrderStateStore(DaprClient client)
        {
            _client = client;
        }

        public async Task<Order?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _client.GetStateAsync<string>(STORE_NAME, $"order:{id}", cancellationToken: cancellationToken);

            if (result != null)
            {
                var order = JsonSerializer.Deserialize<Order>(result);

                return order;
            }
            else
                return null;
        }

        public async Task UpsertAsync(Order state, CancellationToken cancellationToken = default)
        {
            var orderString = JsonSerializer.Serialize(state);
            await _client.SaveStateAsync(STORE_NAME, $"order:{state.Id}", orderString, cancellationToken: cancellationToken);
        }
    }
}
