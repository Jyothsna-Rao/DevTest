using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class AccountRepository : Repository<Account>
    {
        private readonly DevTestContext _dbContextContext;

        public AccountRepository(DevTestContext dbContext) : base(dbContext)
        {
            _dbContextContext = dbContext;
        }




    }
}
