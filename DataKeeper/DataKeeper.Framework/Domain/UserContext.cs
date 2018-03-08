using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class UserContext
    {
        public Guid UserId { get; set; }

        public static UserContext Current
        {
            get
            {
                var principal = Thread.CurrentPrincipal as KeeperPrincipal;
                return new UserContext
                {
                    UserId = principal.UserId
                };
            }
        }
    }
}
