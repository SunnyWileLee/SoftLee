using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Crm.Customer.Models;
using DataKeeper.Crm.Customer.Repositories;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerQueryService : ICustomerQueryService
    {
        private readonly IEntityPageQueryRepositoryProvider _entityPageQueryRepositoryProvider;
        private readonly ICustomerContextProvider _customerContextProvider;

        public PageCollection<CustomerModel> Page(CustomerPageQueryParas customerPageQueryParas)
        {
            var entityPageQueryRepository = _entityPageQueryRepositoryProvider.Provide();
            var customers = entityPageQueryRepository.Page<CustomerEntity>(new EntityPageQueryContext<CustomerEntity>
            {
                ContextProvider = _customerContextProvider,
                PageQueryParas = customerPageQueryParas,
                Predicate = s => s.Name.Contains(customerPageQueryParas.Keyword) || s.Phone.Contains(customerPageQueryParas.Keyword),
                UserId = UserContext.Current.UserId
            });
            var
        }

        public List<CustomerNaiveModel> Query(CustomerQueryParas customerQueryParas)
        {
            throw new NotImplementedException();
        }
    }
}
