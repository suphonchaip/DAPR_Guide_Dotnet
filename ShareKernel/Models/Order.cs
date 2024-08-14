using System.Text.Json.Serialization;

namespace ShareKernel.Models;

public class Order
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName ("name")]
    public string? Name { get; init; }
}
