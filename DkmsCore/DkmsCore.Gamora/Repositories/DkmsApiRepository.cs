using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Gamora.Entities;
using DkmsCore.Gamora.Models;
using Microsoft.EntityFrameworkCore;

namespace DkmsCore.Gamora.Repositories
{
    public class DkmsApiRepository : IDkmsApiRepository
    {
        private readonly GamoraDbContext _context;

        public DkmsApiRepository(GamoraDbContext context)
        {
            _context = context;
        }

        public async Task<List<DkmsApiModel>> GetList(string service)
        {
            var query = from api in _context.Apis
                        join site in _context.Sites on api.SiteId equals site.Id into sites
                        from s in sites.DefaultIfEmpty()
                        where api.Service == service
                        select new DkmsApiModel
                        {
                            Service = api.Service,
                            Host = s.Host
                        };
            var list = await query.ToListAsync();
            return list;
        }
    }
}
