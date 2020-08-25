using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public class UserDetails 
    
    {
        [Key]
        public int UserID { get; set; }

        
        public string UserName { get; set; }

        public Account Account { get; set; }
      

       



    }
}
