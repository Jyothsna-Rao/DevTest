using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
   public interface IPaymentRepository : IRepository<Payment>
    {
        void UpdateAccountBalance(Payment payment);
        decimal CheckAccountBalance(int accountId);
        
    }
}
