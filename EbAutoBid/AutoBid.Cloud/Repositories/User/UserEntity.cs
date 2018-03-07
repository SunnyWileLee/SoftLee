using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories.User
{
    [Table("User")]
    class UserEntity : BaseEntity
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}