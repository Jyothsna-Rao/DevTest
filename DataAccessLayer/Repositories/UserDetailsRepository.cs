using DataAccessLayer.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
   public class UserDetailsRepository : Repository<UserDetails>, IUserDetailsRepository
    {
        private readonly DevTestContext _dbContextContext;

        public UserDetailsRepository(DevTestContext dbContext) : base(dbContext)
        {
            _dbContextContext = dbContext;
        }

        public List<UserDetails> GetUserPaymentDetails(int userId)
        {
            
            var result =
                  (from a in _dbContextContext.Account
                   where a.UserID == userId
                   join p in _dbContextContext.Payment on a.AccountID equals p.AccountID 
                
                   select new UserDetails
                   {
                       UserID = a.UserID,

                       Account = new Account
                       {
                           AccountNo = a.AccountNo,
                           Balance = a.Balance,
                           Payment = new Payment
                           {
                               PaymentDate = Convert.ToDateTime(p.PaymentDate).Date,
                               Amount = p.Amount,
                               PaymentStatus = p.PaymentStatus,
                               Reason = p.PaymentStatus == "Closed" ? p.Reason : null
                           }


                       }
                     
                   }).ToList();

            return result;

        }
    }
}
