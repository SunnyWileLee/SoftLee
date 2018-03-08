using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }

        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
