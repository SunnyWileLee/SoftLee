using DkmsCore.Stark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DkmsCore.Stark.Applications
{
    public class Balancer : IBalancer
    {
        public DkmsApi Balance(List<DkmsApi> apis)
        {
            if (apis == null || apis.Any())
            {
                throw new NullReferenceException("apis");
            }
            var array = apis.OrderBy(s => s.Host).ToArray();
            var random = new Random();
            var next = random.Next(0, 1000);
            var mod = next % array.Length;
            return apis[mod];
        }
    }
}
