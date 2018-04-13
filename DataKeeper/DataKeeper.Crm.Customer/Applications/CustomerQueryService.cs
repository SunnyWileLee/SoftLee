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
using DataKeeper.Framework.Domain.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Entities;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerQueryService : EntityQueryService<CustomerEntity>, ICustomerQueryService
    {
        public CustomerQueryService(IEntityQueryRepositoryProvider entityPageQueryRepositoryProvider,
                                   ICustomerContextProvider contextProvider)
            : base(entityPageQueryRepositoryProvider, contextProvider)
        {

        }

        protected override QueryEntityPageContext<CustomerEntity> CreatePageQueryContext(PageQueryParas pageQueryParas)
        {
            var context = base.CreatePageQueryContext(pageQueryParas);
            var paras = pageQueryParas as CustomerPageQueryParas;
            if (paras != null)
            {
                context.Predicate = s => s.Name.Contains(paras.Keyword) || s.Phone.Contains(paras.Keyword);
            }
            return context;
        }

        protected override QueryEntityContext<CustomerEntity> CreateQueryContext(QueryParas queryParas)
        {
            var context = base.CreateQueryContext(queryParas);
            var paras = queryParas as CustomerQueryParas;
            if (paras != null)
            {
                context.Predicate = s => s.Phone.Contains(paras.Keyword) || s.Name.Contains(paras.Keyword);
            }
            return context;
        }
    }
}
