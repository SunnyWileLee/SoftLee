using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Models
{
    class UserModel : BaseModel
    {
        public static Guid CurrentUserId = Guid.Empty;

        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
