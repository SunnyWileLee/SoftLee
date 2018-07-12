using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DkmsCore.Data.Base.Repositories
{
    public abstract class BasePropertyValueEntity : BaseUserEntity
    {
        public Guid PropertyId { get; set; }
        [MaxLength(500)]
        public string Value { get; set; }
    }
}
