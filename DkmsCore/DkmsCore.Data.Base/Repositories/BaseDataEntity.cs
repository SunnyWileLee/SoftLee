using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DkmsCore.Data.Base.Repositories
{
    public abstract class BaseDataEntity
    {
        public BaseDataEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }

        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
