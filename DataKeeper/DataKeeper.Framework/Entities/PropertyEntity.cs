using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Entities
{
    public abstract class PropertyEntity : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
