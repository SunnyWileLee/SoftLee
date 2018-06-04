using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Hystrix.Entities
{
    class ServiceBucketEntity : DkmsEntity
    {
        public Guid ServiceId { get; set; }
        public int Times { get; set; }
        public int FailTimes { get; set; }
    }
}
