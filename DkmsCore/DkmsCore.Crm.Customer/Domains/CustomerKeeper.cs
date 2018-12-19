using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Crm.Customer.Repositories;
using DkmsCore.Infrustructure.Domains.DomainAdders;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;

namespace DkmsCore.Crm.Customer.Domains
{
    public class CustomerKeeper : ICustomerKeeper
    {
        private readonly IDomainAdderProxy _domainAdderProxy;

        public CustomerKeeper(IDomainAdderProxy domainAdderProxy)
        {
            _domainAdderProxy = domainAdderProxy;
        }

        public async Task<Guid> AddAsync(CustomerModel model)
        {
            var context = new DomainAdderContext
            {
                UserEntity = model.Customer,
            };
            context.Values.AddRange(model.Values.Cast<DkmsPropertyValueEntity>());
            await _domainAdderProxy.HandleAsync(context);
            return context.EntityId;
        }
    }
}
