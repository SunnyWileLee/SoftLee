using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Persistence
{
    public abstract class DkmsStateableEntity : DkmsUserEntity
    {
        public virtual DkmsEntityState State { get; set; } = DkmsEntityState.普通;
    }

    public enum DkmsEntityState
    {
        普通 = 0,
        不可见 = -1
    }
}
