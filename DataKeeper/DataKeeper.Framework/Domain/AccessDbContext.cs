using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public abstract class AccessDbContext
    {
        public virtual Guid UserId { get; set; }
        public virtual IDbContextProvider ContextProvider { get; set; }
    }
}
