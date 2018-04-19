using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Crm.Customer.Models;
using DataKeeper.Framework.Applications;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Applications
{
    public interface ICustomerQueryService
    {
        PageCollection<CustomerModel> Page(PageQueryParameter<CustomerEntity> parameter);
        List<CustomerModel> Query(QueryParameter<CustomerEntity> parameter);
    }
}
