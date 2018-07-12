using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DkmsCore.Data.Base.Repositories
{
    public abstract class BasePropertyEntity : BaseUserEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
