using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
   public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly DevTestContext _dbContextContext;


        public PaymentRepository()
        {

        }

        public PaymentRepository(DevTestContext dbContext) : base(dbContext)
        {
            _dbContextContext = dbContext;
        }
        
       

        public async void UpdateAccountBalance(Payment payment)
        {
           
            var accountRep = new Repository<Account>(_dbContextContext);
            var accountDetails = accountRep.GetById(x => x.AccountID == payment.AccountID);
            if (accountDetails != null)
            {
                accountDetails.Balance -= payment.Amount;
               await  accountRep.UpdateAsync(accountDetails);
            }
          
        }
        public decimal CheckAccountBalance(int accountId)
        {
           
            var accountRep = new Repository<Account>(_dbContextContext);
            var accountBalance = accountRep.GetById(x => x.AccountID == accountId).Balance;
            return accountBalance;

        }
        
    }
}
