using DkmsCore.Thor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Loki.Entities
{
    [Table("Config")]
    public class ConfigEntity : DkmsEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Value { get; set; }
    }
}
