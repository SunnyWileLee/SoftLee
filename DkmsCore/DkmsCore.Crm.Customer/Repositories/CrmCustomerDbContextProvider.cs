using DkmsCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    class CrmCustomerDbContextProvider : IDbContextProvider
    {
        private readonly CrmCustomerDbContext _crmCustomerDbContext;

        public CrmCustomerDbContextProvider(CrmCustomerDbContext crmCustomerDbContext)
        {
            _crmCustomerDbContext = crmCustomerDbContext;
        }

        public DbContext Provide()
        {
            return _crmCustomerDbContext;
        }
    }
}
