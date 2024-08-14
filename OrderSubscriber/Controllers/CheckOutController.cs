using Dapr;
using Microsoft.AspNetCore.Mvc;
using ShareKernel.Models;
using System.Text.Json;

namespace OrderSubscriber.Controllers
{
    [ApiController]
    public class CheckOutController : Controller
    {
        [Topic("orderpubsub", "order")]
        [HttpPost("checkout")]
        public async Task<IActionResult> Subscribe([FromBody] object payload)
        {
            var resp = JsonSerializer.Deserialize<OrderResponse>(payload.ToString());
            // แสดง payload ที่รับมาจาก RabbitMQ
            Console.WriteLine("Received message: " + resp.data.Name);

            // ประมวลผล payload ที่นี่

            return Ok();
        }
    }
}

public class OrderResponse
{
    public Order? data { get; set; }
}
