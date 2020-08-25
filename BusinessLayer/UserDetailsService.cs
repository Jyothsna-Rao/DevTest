using DataAccessLayer.Infrastructure;
using DataAccessLayer.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
   public class UserDetailsService : IUserService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        //  private readonly IPaymentRepository _paymentRepository;

        public UserDetailsService(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public List<UserDetails> GetUserPaymentDetails(int userId)
        {
            var result = _userDetailsRepository.GetUserPaymentDetails(userId);
            return result;
        }
    }
}
