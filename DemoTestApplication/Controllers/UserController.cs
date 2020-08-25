using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DemoTestApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestApplication.Controllers
{
    [Route("api/User")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{UserID}")]
        public UserPaymentsViewModel GetUserPayments(int UserID)
        {
            
           var payments = _userService.GetUserPaymentDetails(UserID);
            //sort by newest date
            var sortedPayments = payments.OrderByDescending(x => x.Account.Payment.PaymentDate).Select(d => d.Account.Payment);

            var upvm = new UserPaymentsViewModel();
            List<ProcessPaymentViewModel> lstPayments = new List<ProcessPaymentViewModel>();
            upvm.AccountBalance = payments.Select(x => x.Account.Balance).FirstOrDefault();

            foreach (var p in sortedPayments)
            {

                ProcessPaymentViewModel pvm = new ProcessPaymentViewModel();


                    pvm.PaymentDate = p.PaymentDate.Date;
                    pvm.Amount = p.Amount;
                    pvm.PaymentStatus = p.PaymentStatus;
                     if(p.PaymentStatus == "Closed")
                     {
                    pvm.Reason = p.Reason;
                     }

                   
                

                lstPayments.Add(pvm);
            }


            upvm.Payments = lstPayments;


            return upvm;

        }
    }
}