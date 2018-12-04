using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    interface IGoodsStockRepository
    {
        Task<int> ChangeStockAsync(Guid userId, Guid goodsId, decimal stock);
        Task<Guid> AddAsync(Guid userId, GoodsStockEntity entity);
        Task<List<GoodsStockEntity>> GetListAsync(Guid userId, IEnumerable<Guid> goodsIds);
    }
}
