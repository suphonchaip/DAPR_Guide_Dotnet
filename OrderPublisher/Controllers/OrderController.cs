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
    public async Task<IActionResult> CheckInOrderAsync([FromBody] string message)
    {
       
        _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]-Publish => Message : {message}");
        await _orderPubService.PublishStringAsync(message);
        return Ok(message);
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
        await _orderPubService.PublishAsync(order);
        return Ok(req);
    }
}

