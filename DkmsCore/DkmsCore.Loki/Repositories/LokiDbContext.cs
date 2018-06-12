using DkmsCore.Loki.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Loki.Repositories
{
    public class LokiDbContext : DbContext
    {

        public DbSet<ConfigEntity> Configs { get; set; }
    }
}
