using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
   public class Payment 
    {
        [Key]
        public int ID { get; set; }
       
        public decimal Amount { get; set; }
              
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string Reason { get; set; }
        public int AccountID { get; set; }
       
    }
}
