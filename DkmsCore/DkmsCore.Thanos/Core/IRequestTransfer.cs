using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Thanos.Core
{
    public interface IRequestTransfer
    {
        string Method { get; }
        Task Transfer(TransferContext context);
    }
}
