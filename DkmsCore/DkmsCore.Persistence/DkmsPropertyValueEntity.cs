using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DkmsCore.Persistence
{
    public abstract class DkmsPropertyValueEntity : DkmsUserEntity
    {
        public virtual Guid InstanceId { get; set; }

        public virtual Guid PropertyId { get; set; }
        [MaxLength(500)]
        public virtual string Value { get; set; }
    }
}
