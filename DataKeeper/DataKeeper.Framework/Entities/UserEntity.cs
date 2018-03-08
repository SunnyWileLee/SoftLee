using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Entities
{
    public abstract class UserEntity : BaseEntity
    {
        public virtual Guid UserId { get; set; }
    }
}
