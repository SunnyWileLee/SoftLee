using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Infrustructure
{
    public class ScopeEntityAttribute : Attribute, IScoper
    {
        private readonly string _scope;

        public ScopeEntityAttribute(string scope)
        {
            _scope = scope;
        }

        public string Scope => _scope;
    }
}
