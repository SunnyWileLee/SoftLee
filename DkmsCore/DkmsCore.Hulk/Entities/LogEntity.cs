using DkmsCore.Thor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Hulk.Entities
{
    [Table("Log")]
    public class LogEntity : DkmsEntity
    {
        [MaxLength(2000)]
        public string Message { get; set; }
        public LogLevel Level { get; set; }
    }

    public enum LogLevel
    {
        Warn = 1,
        Info = 2,
        Exception = 3
    }
}
