using System.Text.Json.Serialization;

namespace ShareKernel.Models;

public class Order
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName ("name")]
    public string? Name { get; init; }
}
