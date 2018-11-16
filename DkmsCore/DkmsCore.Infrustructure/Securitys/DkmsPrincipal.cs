using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace DkmsCore.Infrustructure.Securitys
{
    public class DkmsPrincipal : IPrincipal
    {
        public virtual IIdentity Identity => new DkmsIdentity();

        public virtual bool IsInRole(string role)
        {
            return true;
        }

        public DkmsUserContext DkmsUserContext { get; set; }
    }
}
