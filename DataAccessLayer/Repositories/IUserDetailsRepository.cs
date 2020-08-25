using DataAccessLayer.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
  public  interface IUserDetailsRepository : IRepository<UserDetails>
    {
        List<UserDetails> GetUserPaymentDetails(int UserId);
    }
}
