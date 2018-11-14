using DkmsCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public class CustomerPropertyValueRepository : DkmsPropertyValueRepository, ICustomerPropertyValueRepository
    {
        public CustomerPropertyValueRepository(CrmCustomerDbContext dbContext) : base(dbContext)
        {

        }
    }
}
