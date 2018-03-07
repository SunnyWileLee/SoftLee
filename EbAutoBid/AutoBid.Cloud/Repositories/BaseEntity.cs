using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}