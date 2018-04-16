using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Models
{
    public class CustomerQueryParameter : PageQueryParameter<CustomerEntity>
    {
        public string Keyword { get; set; }
    }
}
