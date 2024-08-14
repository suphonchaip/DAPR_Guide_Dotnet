using Dapr.Client;
using ShareKernel.Core.Interfaces;
using ShareKernel.Models;

namespace OrderPublisher.Services
{
    public class OrderPublisherService : IPublisher<Order>
    {
        private readonly DaprClient _client;
        private static string PUBSUB_NAME = "orderpubsub";
        private static string TOPIC_NAME = "order";

        public OrderPublisherService(DaprClient client)
        {
            _client = client;
        }
        public async Task PublishAsync(Order request, CancellationToken cancellationToken = default)
        {
            //var reqStr = JsonSerializer.Serialize(request);
            await _client.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, request, cancellationToken);
        }

        public async Task PublishStringAsync(string message, CancellationToken cancellationToken = default)
        {
            await _client.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, message, cancellationToken);
        }
    }
}
