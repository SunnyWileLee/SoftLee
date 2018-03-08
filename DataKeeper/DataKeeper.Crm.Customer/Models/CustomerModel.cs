using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Models
{
    public class CustomerModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<CustomerPropertyValueModel> Properties { get; set; }
    }
}
