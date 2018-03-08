using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Repositories
{
    interface ICustomerQueryRepository
    {
        List<CustomerEntity> Search(Expression<Func<CustomerEntity, bool>> predict);
        PageCollection<CustomerEntity> Page(Expression<Func<CustomerEntity, bool>> predict, PageQueryParas page);
    }
}
