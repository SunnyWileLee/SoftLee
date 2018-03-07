using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models.User
{
    public class UserModel : BaseModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}