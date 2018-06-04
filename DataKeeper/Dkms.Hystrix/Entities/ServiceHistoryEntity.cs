using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Hystrix.Entities
{
    class ServiceHistoryEntity : DkmsEntity
    {
        public Guid ServiceId { get; set; }
    }
}
