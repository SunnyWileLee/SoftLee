using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    class KeeperIdentity : IIdentity
    {
        public string Name => UserId.ToString();

        public string AuthenticationType => "token";

        public bool IsAuthenticated => true;

        public Guid UserId { get; set; }
    }
}
