using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public delegate void RepositoryHandler(object sender, RepositoryEventArgs args);

    public class RepositoryEventArgs : EventArgs
    {
        public AccessDbContext AccessDbContext { get; set; }
        public Guid NewEntityId { get; set; }
        public Guid EntityId { get; set; }
        public int Count { get; set; }

        public BaseEntity Instance { get; set; }
        public IEnumerable<BaseEntity> Instances { get; set; }

        public Exception Exception { get; set; }
        public string ErrorMessage { get; set; }
    }
}
