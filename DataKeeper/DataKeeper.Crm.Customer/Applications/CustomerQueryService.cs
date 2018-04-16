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
        public CustomerQueryService(IRepositoryProviderProvider repositoryProviderProvider,
                                    ICustomerContextProvider contextProvider)
            : base(repositoryProviderProvider, contextProvider)
        {

        }
    }
}
