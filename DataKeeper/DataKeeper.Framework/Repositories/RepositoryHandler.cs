using DataKeeper.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public delegate void RepositoryHandler(object sender, RepositoryEventArgs args);

    public class RepositoryEventArgs: EventArgs
    {
        public AccessDbContext AccessDbContext { get; set; }
        public Guid NewId { get; set; }
    }
}
