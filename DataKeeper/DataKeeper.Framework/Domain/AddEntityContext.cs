using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class AddEntityContext<TEntity> : AccessDbContext
        where TEntity : UserEntity
    {
        public TEntity Entity { get; set; }

        public event AddEntityEvent ExecuteCompleted;
        public event AddEntityEvent BeforeExecute;
        public event AddEntityEvent OnSuccess;
        public event AddEntityEvent OnFail;
    }

    public delegate void AddEntityEvent();
}
