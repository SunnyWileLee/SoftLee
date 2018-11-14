using DkmsCore.Crm.Customer.Models;
using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Domains
{
    public interface ICustomerSearcher
    {
        DkmsPage<CustomerModel> GetPage(CustomerPageQuery query);
    }
}
