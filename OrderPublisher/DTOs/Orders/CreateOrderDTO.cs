using System.Text.Json.Serialization;

namespace OrderPublisher.DTOs.Orders
{
    public record CreateOrderDTO(
        [property: JsonPropertyName("name")] string Name
        );

}
