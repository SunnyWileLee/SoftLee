using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Data.Base.Repositories
{
    public abstract class BaseUserEntity: BaseDataEntity
    {
        public virtual Guid UserId { get; set; }
    }
}
