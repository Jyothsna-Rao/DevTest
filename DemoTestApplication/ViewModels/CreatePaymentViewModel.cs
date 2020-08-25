using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTestApplication.ViewModels
{
    public class CreatePaymentViewModel
    {
       
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }

        public int UserID { get; set; }
        public int AccountID { get; set; }
       


    }
}
