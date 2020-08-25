using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer.Infrastructure;
using DemoTestApplication.Validations;
using DemoTestApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestApplication.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    [ValidateModel]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
      

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
        [HttpPost]
        [Route("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody]CreatePaymentViewModel newPayment)
        {
            if (ModelState.IsValid)
            {
               

                Payment payment = new Payment
                {
                    AccountID = newPayment.AccountID,

                    PaymentDate = newPayment.PaymentDate ?? System.DateTime.UtcNow,

                    Amount = newPayment.Amount ?? 0.0m
                };

                var result = await  _paymentService.CreatePayment(payment);
                CreatePaymentViewModel resultSet = new CreatePaymentViewModel
                {
                    PaymentStatus = result.PaymentStatus,
                    Amount = result.Amount,
                    PaymentDate = result.PaymentDate

                };
                return Ok(resultSet);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("payments")]
        public ActionResult<List<Payment>> GetAllPayments()
        {
            var lstPayment = _paymentService.GetAllPayments(); 
            return lstPayment.ToList();
        }
        [HttpPut("CancelPayment")]
        public async Task<IActionResult> CancelPayment(int PaymentId, string Reason = "")
        {
            
            var payment = await _paymentService.CancelPayment(PaymentId, Reason);
            if (payment.PaymentStatus == "Closed")
                return Ok(payment);
            else
                return NotFound("No pending payment to Cancel");

        }
        [HttpPut("ProcessPayment/{PaymentId}")]
        public async Task<IActionResult> ProcessPayment(int PaymentId)
        {
            
            var payment = await _paymentService.ProcessPayment(PaymentId);
            if (payment.PaymentStatus == "Processed")
                return Ok(payment);
            else
                return NotFound("Payment cannot be processed");

         }

        
    }
}