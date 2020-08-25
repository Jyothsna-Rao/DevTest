using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account Update(Account account);
    }
}
