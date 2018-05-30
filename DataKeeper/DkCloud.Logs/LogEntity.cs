using DkCloud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Logs
{
    public class LogEntity : BaseEntity
    {
        public string Message { get; set; }
    }
}
