using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    interface IGoodsStockHistoryRepository
    {
        Task<Guid> AddAsync(Guid userId, GoodsStockHistoryEntity history);
        Task<DkmsPage<GoodsStockHistoryEntity>> GetPageAsync(GoodsStockHistoryPageQuery query);
    }
}
