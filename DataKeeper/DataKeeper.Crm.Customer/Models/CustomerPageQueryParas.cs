using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Models
{
    public class CustomerPageQueryParas : PageQueryParameter<CustomerEntity>
    {
        public string Keyword { get; set; }
    }
}
