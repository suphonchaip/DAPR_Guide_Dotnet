using Dapr;
using Microsoft.AspNetCore.Mvc;
using ShareKernel.Models;
using System.Text.Json;

namespace OrderSubscriber.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ILogger<CheckOutController> _logger;
        private const string PUBSUB_NAME = "pubsub";
        private const string TOPIC_NAME = "order";

        public CheckOutController(ILogger<CheckOutController> logger)
        {
            _logger = logger;
        }

        [Route("/order")]
        [HttpPost]
        [Topic(PUBSUB_NAME, TOPIC_NAME)]
        public IActionResult CheckOutOrder([FromBody] string message)
        {
            //var orderOvj = JsonSerializer.Deserialize<Order>(order);
            _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]-Receive Order => message : {message}");
            return Ok(message);
        }
    }
}
