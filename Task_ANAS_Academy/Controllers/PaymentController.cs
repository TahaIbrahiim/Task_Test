using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBitcoin.Payment;
using Stripe;
using Task_ANAS_Academy.Models;

namespace Task_ANAS_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            var options = new ChargeCreateOptions
            {
                Amount = request.Amount,
                Currency = "usd",
                Source = request.TokenId,
                Description = "Sample Charge"
            };

            var service = new ChargeService();
            var charge = await service.CreateAsync(options);
            return Ok(charge);
        }
    }
}
