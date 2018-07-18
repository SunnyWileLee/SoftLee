using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public interface ICustomerRepository
    {
        Guid AddCustomer(CustomerEntity customer);
    }
}
