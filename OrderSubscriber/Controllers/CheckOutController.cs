using Dapr;
using Microsoft.AspNetCore.Mvc;
using OrderSubscriber.Models;
using ShareKernel.Models;

namespace OrderSubscriber.Controllers
{
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CheckOutController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Topic("orderpubsub", "order")]
        [HttpPost("checkout")]
        public async Task<IActionResult> Subscribe([FromBody] OrderResponse payload)
        {
            ////var resp = JsonSerializer.Deserialize<OrderResponse>(payload.ToString());
            //// แสดง payload ที่รับมาจาก RabbitMQ
            //Console.WriteLine("Received message: " + payload.data.Name);

            // ประมวลผล payload ที่นี่
            var newCheckOut = new CheckOutOrder
            {
                Id = Guid.NewGuid(),
                Name = payload == null ? "" : payload.data.Name,
                TimeStamp = DateTime.Now,
            };
            _context.CheckOutOrders.Add(newCheckOut);
            await _context.SaveChangesAsync();

            return Ok(payload);
        }
    }
}

public class OrderResponse
{
    public Order? data { get; set; }
}
