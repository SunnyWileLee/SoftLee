using DkmsCore.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Domains
{
    public interface ICustomerKeeper
    {
        Task<Guid> AddAsync(CustomerModel model);
    }
}
