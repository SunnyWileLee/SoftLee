using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Domains.Tokens
{
    public class TokenBuilder : ITokenBuilder
    {
        public string Build()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
    }
}
