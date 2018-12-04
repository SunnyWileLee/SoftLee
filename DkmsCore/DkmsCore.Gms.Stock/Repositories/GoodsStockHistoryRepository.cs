using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    public class GoodsStockHistoryRepository : IGoodsStockHistoryRepository
    {
        private readonly IDkmsRepository _dkmsRepository;

        public async Task<Guid> AddAsync(Guid userId, GoodsStockHistoryEntity history)
        {
            history.UserId = userId;
            return await _dkmsRepository.AddAsync(history);
        }

        public async Task<DkmsPage<GoodsStockHistoryEntity>> GetPageAsync(GoodsStockHistoryPageQuery query)
        {
            return await _dkmsRepository.GetPageAsync(query.BuildPredicate(), query.BuildOrderBy(), query);
        }
    }
}
