using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using OrderPublisher.DTOs.Orders;
using OrderPublisher.Services;
using ShareKernel.Models;

namespace OrderPublisher.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderPublisherService _orderPubService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(OrderPublisherService orderPubService,
                           ILogger<OrderController> logger)
    {
        _orderPubService = orderPubService;
        _logger = logger;
    }

    [HttpPost("check-in")]
    public async Task<IActionResult> CheckInAsync([FromBody] CreateOrderDTO req)
    {
        DateTime now = DateTime.Now;
        var ticks = (int)now.Ticks;
        var order = new Order
        {
            Id = ticks,
            Name = req.Name,
        };
        _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]-Publish => Id : {order.Id}. Name: {order.Name}");
        await _orderPubService.PublishAsync(order);
        return Ok(req);
    }
}

