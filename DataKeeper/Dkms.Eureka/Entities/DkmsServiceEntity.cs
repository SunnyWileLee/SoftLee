using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Eureka.Entities
{
    [Table("DkmsService")]
    public class DkmsServiceEntity : DkmsEntity
    {
        [MaxLength(200)]
        public string Host { get; set; }
        [MaxLength(500)]
        public string Service { get; set; }
    }
}
