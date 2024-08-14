using Dapr;
using Microsoft.AspNetCore.Mvc;
using ShareKernel.Models;

namespace OrderSubscriber.Controllers
{
    [ApiController]
    public class CheckOutController : Controller
    {
        [Topic("orderpubsub", "order")]
        [HttpPost("checkout")]
        public void getCheckout([FromBody] string payload)
        {
            Console.WriteLine("Subscriber received : " + payload);
        }
    }
}
