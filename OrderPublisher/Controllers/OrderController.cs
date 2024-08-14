using Microsoft.AspNetCore.Mvc;
using OrderPublisher.DTOs.Orders;
using ShareKernel.Models;
using DaprClient = Dapr.Client.DaprClient;

namespace OrderPublisher.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    //private readonly OrderPublisherService _orderPubService;
    private readonly ILogger<OrderController> _logger;
    public readonly DaprClient _client;

    private static string PUBSUB_NAME = "orderpubsub";
    private static string TOPIC_NAME = "order";

    public OrderController(DaprClient client,
                           ILogger<OrderController> logger)
    {
        _client = client;
        _logger = logger;
    }

    //[HttpPost("check-in")]
    //public async Task<IActionResult> CheckInOrderAsync([FromBody] string message)
    //{

    //    _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]-Publish => Message : {message}");
    //    await _client.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, message, CancellationToken.None);
    //    //await _orderPubService.PublishStringAsync(message);
    //    return Ok(message);
    //}

    [HttpPost("publish")]
    public async Task<IActionResult> Publish([FromBody] object message)
    {
        await _client.PublishEventAsync("orderpubsub", "order", message);
        return Ok("Message published.");
    }

    [HttpPost("check-in/v2")]
    public async Task<IActionResult> CheckIn2OrderAsync([FromBody] CreateOrderDTO req)
    {
        DateTime now = DateTime.Now;
        string dateString = now.ToString("yyyyMMddHHmmss");
        long dateNumber = long.Parse(dateString);
        var order = new Order
        {
            Id = dateNumber,
            Name = req.Name,
        };
        _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]-Publish => Id : {order.Id}. Name: {order.Name}");
        await _client.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, order, CancellationToken.None);
        //await _orderPubService.PublishAsync(order);
        return Ok(order);
    }
}

