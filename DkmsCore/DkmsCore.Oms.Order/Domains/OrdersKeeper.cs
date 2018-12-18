using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Domains.Abstract.DomainAdders;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Oms.Order.Models;
using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;

namespace DkmsCore.Oms.Order.Domains
{
    public class OrdersKeeper : IOrdersKeeper
    {
        private readonly IDomainAdderProxy _domainAdderProxy;

        public OrdersKeeper(IDomainAdderProxy domainAdderProxy)
        {
            _domainAdderProxy = domainAdderProxy;
        }

        public async Task<Guid> AddAsync(OrdersModel model)
        {
            var context = new DomainAdderContext
            {
                UserEntity = model.Order,
            };
            context.Values.AddRange(model.Values.Cast<DkmsPropertyValueEntity>());
            await _domainAdderProxy.HandleAsync(context);
            return context.EntityId;
        }
    }
}
