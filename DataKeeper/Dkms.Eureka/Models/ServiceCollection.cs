using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Eureka.Models
{
    public class ServiceCollection
    {
        public string Host { get; set; }
        public List<string> Services { get; set; }
    }
}
