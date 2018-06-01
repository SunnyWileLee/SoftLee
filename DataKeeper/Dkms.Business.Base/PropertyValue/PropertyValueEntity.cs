using Dkms.Business.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Business.Base.PropertyValue
{
    public abstract class PropertyValueEntity : UserEntity
    {
        public Guid PropertyId { get; set; }
        public string Value { get; set; }
    }
}
