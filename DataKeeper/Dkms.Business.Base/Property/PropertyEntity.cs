using Dkms.Business.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Business.Base.Property
{
    public abstract class PropertyEntity : UserEntity
    {
        public string Name { get; set; }
    }
}
