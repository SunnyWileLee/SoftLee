using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Infrustructure
{
    public interface IScoper
    {
        string Scope { get; }
    }
}
