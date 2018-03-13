using DataKeeper.Crm.Customer.Models;
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
        PageCollection<CustomerModel> Page(CustomerPageQueryParas customerPageQueryParas);
        List<CustomerNaiveModel> Query(CustomerQueryParas customerQueryParas);
    }
}
