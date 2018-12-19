using DkmsCore.Infrustructure.Securitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Domains.DomainAdders
{
    class DomainAdderProxy : IDomainAdderProxy
    {
        private readonly IDomainAdder[] _domainAdders;

        public DomainAdderProxy(IDomainAdder[] domainAdders)
        {
            _domainAdders = domainAdders.OrderBy(s => s.Order).ToArray();
        }

        public async Task HandleAsync(DomainAdderContext context)
        {
            context.UserId = DkmsUserContext.UserIdDefaultEmpty;
            foreach (var adder in _domainAdders)
            {
                await adder.HandleAsync(context);
            }
        }
    }
}
