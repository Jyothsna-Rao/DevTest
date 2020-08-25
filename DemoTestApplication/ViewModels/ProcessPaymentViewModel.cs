using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTestApplication.ViewModels
{
    public class ProcessPaymentViewModel 
    {
        
        public decimal Amount { get; set; }
        
        public DateTime PaymentDate { get; set; }
       
      
        public string PaymentStatus { get; set; }

        
        public string Reason { get; set; }


    }
}
