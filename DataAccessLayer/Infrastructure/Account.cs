using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
   public class Account 
    {
        [Key]
        public int AccountID { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNo { get; set; }

        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

      
        public int UserID { get; set; }

       
        public Payment Payment { get; set; }



    }
}
