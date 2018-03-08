using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public abstract class PropertyValueModel : BaseModel
    {
        public virtual Guid PropertyId { get; set; }
        public virtual string Value { get; set; }
    }
}
