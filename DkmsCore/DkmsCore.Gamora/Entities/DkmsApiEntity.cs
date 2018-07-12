using DkmsCore.Thor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DkmsCore.Gamora.Entities
{
    [Table("DkmsApi")]
    public class DkmsApiEntity : DkmsEntity
    {
        public Guid SiteId { get; set; }
        [MaxLength(200)]
        public string Service { get; set; }
    }
}
