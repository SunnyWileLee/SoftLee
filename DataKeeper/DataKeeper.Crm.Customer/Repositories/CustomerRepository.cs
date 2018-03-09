using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Crm.Customer.Entities;

namespace DataKeeper.Crm.Customer.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public Guid Add(CustomerEntity customer)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var customers = context.Set<CustomerEntity>();
                customers.Add(customer);
                return context.SaveChanges() > 0 ? customer.Id : Guid.Empty;
            }
        }
    }
}
