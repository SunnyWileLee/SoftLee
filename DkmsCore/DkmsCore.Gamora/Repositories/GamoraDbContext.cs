using DkmsCore.Gamora.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gamora.Repositories
{
    public class GamoraDbContext : DbContext
    {
        public GamoraDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<DkmsApiEntity> Apis { get; set; }
        public DbSet<DkmsSiteEntity> Sites { get; set; }
    }
}
