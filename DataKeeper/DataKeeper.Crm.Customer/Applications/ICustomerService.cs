using DataKeeper.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Applications
{
    public interface ICustomerService
    {
        Guid Add(CustomerModel model);

    }
}
