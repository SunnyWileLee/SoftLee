using DataKeeper.Crm.Customer.Domain;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Repositories
{
    class CustomerContextProvider : CrmCustomerScoper, IDbContextProvider
    {
        public DbContext Provide()
        {
            return new CustomerContext("DataKeeperConnection");
        }
    }
}
