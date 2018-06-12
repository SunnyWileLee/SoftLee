using System;
using System.ComponentModel.DataAnnotations;

namespace DkmsCore.Thor
{
    public class DkmsEntity
    {
        public DkmsEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
