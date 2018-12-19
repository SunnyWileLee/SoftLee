using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Domains.DomainAdders
{
    public interface IDomainAdderProxy
    {
        Task HandleAsync(DomainAdderContext context);
    }
}
