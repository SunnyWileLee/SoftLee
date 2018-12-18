using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Domains.Abstract.DomainAdders
{
    public class DomainAdderContext
    {
        public Guid UserId { get; set; }
        public DkmsUserEntity UserEntity { get; set; }
        public Guid EntityId { get; set; }
        public List<DkmsPropertyValueEntity> Values { get; set; } = new List<DkmsPropertyValueEntity> { };
    }
}
