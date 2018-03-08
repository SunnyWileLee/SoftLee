using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class KeeperPrincipal : IPrincipal
    {
        private KeeperIdentity _identity;

        public IIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    _identity = new KeeperIdentity { UserId = this.UserId };
                }
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public Guid UserId { get; set; }
    }
}
