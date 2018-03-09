using DataKeeper.Crm.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Repositories
{
    interface ICustomerRepository
    {
        Guid Add(CustomerEntity customer);
    }
}
