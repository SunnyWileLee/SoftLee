
using DkmsCore.Thor;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DkmsCore.Gamora.Entities
{
    [Table("DkmsSite")]
    public class DkmsSiteEntity : DkmsEntity
    {
        [MaxLength(200)]
        public string Host { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string DocUrl { get; set; }
    }
}
