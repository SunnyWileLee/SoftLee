using DkmsCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Domains.Abstract.DomainAdders
{
    class DomainEntityPropertyValueAdder : IDomainAdder
    {
        private readonly IDkmsUserRepository _dkmsUserRepository;
        public decimal Order => 2;

        public DomainEntityPropertyValueAdder(IDkmsUserRepository dkmsUserRepository)
        {
            _dkmsUserRepository = dkmsUserRepository;
        }

        public async Task HandleAsync(DomainAdderContext context)
        {
            if (!context.Values.Any())
            {
                return;
            }
            if (context.EntityId == Guid.Empty)
            {
                return;
            }
            foreach (var value in context.Values)
            {
                value.InstanceId = context.EntityId;
                await _dkmsUserRepository.AddAsync(context.UserId, value);
            }
        }
    }
}
