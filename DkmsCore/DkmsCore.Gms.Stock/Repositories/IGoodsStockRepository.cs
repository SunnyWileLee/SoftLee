using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    interface IGoodsStockRepository
    {
        Task<int> ChangeStockAsync(string goodsId, decimal stock);
        Task<Guid> AddAsync(GoodsStockEntity entity);
    }
}
