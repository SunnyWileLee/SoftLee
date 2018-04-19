using DataKeeper.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Domain
{
    public class CrmCustomerScoper : IScoper
    {
        public const string ScopeValue = "CrmCustomer";

        public virtual string Scope => ScopeValue;
    }
}
