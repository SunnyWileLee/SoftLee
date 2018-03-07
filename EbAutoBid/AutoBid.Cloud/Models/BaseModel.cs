using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}