using DataAccessLayer.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
   public interface IUserService
    {
        List<UserDetails> GetUserPaymentDetails(int userId);
    }
}
