using DkCloud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Config
{
    public class ConfigEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
