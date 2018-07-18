using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DkmsCore.Thor
{
    public abstract class DkmsPropertyValueEntity : DkmsUserEntity
    {
        public Guid PropertyId { get; set; }
        [MaxLength(500)]
        public string Value { get; set; }
    }
}
