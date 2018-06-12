using DkmsCore.Hulk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Hulk.Repositories
{
    interface ILogRepository
    {
        Task<int> Save(LogEntity log);
    }
}
