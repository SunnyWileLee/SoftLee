using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Business.Base.Entity
{
    public abstract class UserEntity : DkmsEntity
    {
        public Guid UserId { get; set; }
    }
}
