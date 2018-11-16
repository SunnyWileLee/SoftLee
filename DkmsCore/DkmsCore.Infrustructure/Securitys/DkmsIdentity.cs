using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace DkmsCore.Infrustructure.Securitys
{
    public class DkmsIdentity : IIdentity
    {
        public string Name => string.Empty;

        public string AuthenticationType => "Token";

        public bool IsAuthenticated => true;
    }
}
