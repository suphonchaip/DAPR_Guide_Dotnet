using ShareKernel.Core.Interfaces;
using ShareKernel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaprStateStore.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IStateStore<Order> _orderStateStore;

    public OrderController(ILogger<OrderController> logger, IStateStore<Order> orderStateStore)
    {
        _logger = logger;
        _orderStateStore = orderStateStore;
    }

    [HttpPost("state/{id}")]
    public async Task<IActionResult> PostStateAsync(int id)
    {
        var current = await _orderStateStore.GetAsync(id);
        if (current == null)
        {
            current = new Order
            {
                Id = id,
                Name = DateTime.UtcNow.ToString("ddMMyyyy-HHmmss"),
            };
            await _orderStateStore.UpsertAsync(current);
        }

        return Ok(current);
    }

    [HttpGet("state/{id}")]
    public async Task<IActionResult> GetStateByIdAsync(int id)
    {
        var current = await _orderStateStore.GetAsync(id);
        if (current == null)
            return NotFound();
        return Ok(current);
    }
}
