using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPayService.Domain.Dtos;
using RapidPayService.Domain.Interfaces;
using System.Threading.Tasks;

namespace RapidPayService.Web.Controllers
{
    public class PaymentsController : ApiControllerBase 
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController( IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<PaymentDto>> InsertPayment(PaymentDto payment)
        {
            var newPayment = await _paymentService.Insert(payment);
            return Ok(newPayment);
        }

    }
}
