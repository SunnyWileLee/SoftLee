using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Persistence
{
    public abstract class DkmsUserEntity: DkmsEntity
    {
        public virtual Guid UserId { get; set; }
    }
}
