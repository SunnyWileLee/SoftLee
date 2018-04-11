using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Crm.Customer.Models;
using DataKeeper.Crm.Customer.Repositories;
using DataKeeper.Framework.Applications;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerQueryService : EntityQueryService<CustomerEntity>, ICustomerQueryService
    {
        public CustomerQueryService(IEntityQueryRepositoryProvider entityPageQueryRepositoryProvider,
                                   ICustomerContextProvider contextProvider)
            : base(entityPageQueryRepositoryProvider, contextProvider)
        {

        }

        protected override QueryEntityPageContext<CustomerEntity> CreatePageContext(PageQueryParas pageQueryParas)
        {
            var context = base.CreatePageContext(pageQueryParas);
            var paras = pageQueryParas as CustomerPageQueryParas;
            if (paras != null)
            {
                context.Predicate = s => s.Name.Contains(paras.Keyword) || s.Phone.Contains(paras.Keyword);
            }
            return context;
        }

        public List<CustomerNaiveModel> Query(CustomerQueryParas customerQueryParas)
        {
            throw new NotImplementedException();
        }
    }
}
