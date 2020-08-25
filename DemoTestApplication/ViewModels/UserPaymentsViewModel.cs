using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTestApplication.ViewModels
{
    public class UserPaymentsViewModel
    {
        public decimal AccountBalance { get; set; }
       public List<ProcessPaymentViewModel> Payments { get; set; }

    }
}
