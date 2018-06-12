using DkmsCore.Hulk.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Hulk.Repositories
{
    public class HulkDbContext : DbContext
    {
        public HulkDbContext()
        {

        }

        public DbSet<LogEntity> Logs { get; set; }
    }
}
