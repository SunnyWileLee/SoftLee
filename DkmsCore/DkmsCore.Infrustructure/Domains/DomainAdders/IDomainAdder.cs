using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Domains.DomainAdders
{
    public interface IDomainAdder
    {
        decimal Order { get; }
        Task HandleAsync(DomainAdderContext context);
    }
}
