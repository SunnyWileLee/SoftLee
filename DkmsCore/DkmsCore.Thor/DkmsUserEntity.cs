using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Thor
{
    public abstract class DkmsUserEntity: DkmsEntity
    {
        public virtual Guid UserId { get; set; }
    }
}
