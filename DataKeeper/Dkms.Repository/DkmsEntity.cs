using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public abstract class DkmsEntity
    {
        protected DkmsEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }

        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
