using DkmsCore.Gamora.Entities;
using DkmsCore.Gamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gamora.Repositories
{
    public interface IDkmsApiRepository
    {
        Task<List<DkmsApiModel>> GetList(string service);
    }
}
