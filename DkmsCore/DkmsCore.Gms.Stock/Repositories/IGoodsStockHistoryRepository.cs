using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    interface IGoodsStockHistoryRepository
    {
        Task<Guid> AddAsync(GoodsStockHistoryEntity history);
        Task<List<>>
    }
}
