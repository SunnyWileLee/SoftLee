using DkmsCore.Stark.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Stark.Applications
{
    public interface IBalancer
    {
        DkmsApi Balance(List<DkmsApi> apis);
    }
}
