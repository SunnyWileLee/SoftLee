using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }

        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
