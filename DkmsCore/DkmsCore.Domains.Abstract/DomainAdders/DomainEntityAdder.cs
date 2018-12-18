using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;

namespace DkmsCore.Domains.Abstract.DomainAdders
{
    class DomainEntityAdder : IDomainAdder
    {
        private readonly IDkmsUserRepository _dkmsUserRepository;
        public decimal Order => 1;
        public DomainEntityAdder(IDkmsUserRepository dkmsUserRepository)
        {
            _dkmsUserRepository = dkmsUserRepository;
        }
        public async Task HandleAsync(DomainAdderContext context)
        {
            var id = await _dkmsUserRepository.AddAsync(context.UserId, context.UserEntity);
            context.EntityId = id;
        }
    }
}
