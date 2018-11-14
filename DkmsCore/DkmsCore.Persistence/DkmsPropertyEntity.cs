using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DkmsCore.Persistence
{
    public abstract class DkmsPropertyEntity : DkmsUserEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
