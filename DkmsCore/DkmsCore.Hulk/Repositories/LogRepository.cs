using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Hulk.Entities;

namespace DkmsCore.Hulk.Repositories
{
    class LogRepository : ILogRepository
    {
        private readonly HulkDbContext _context;

        public LogRepository(HulkDbContext context)
        {
            _context = context;
        }

        public async Task<int> Save(LogEntity log)
        {
            _context.Logs.Add(log);
            return await _context.SaveChangesAsync();
        }
    }
}
