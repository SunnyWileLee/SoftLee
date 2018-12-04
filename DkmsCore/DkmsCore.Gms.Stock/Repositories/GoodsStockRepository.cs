using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    public class GoodsStockRepository : IGoodsStockRepository
    {
        private readonly IDkmsRepository _dkmsRepository;

        public GoodsStockRepository(IDkmsRepository dkmsRepository)
        {
            _dkmsRepository = dkmsRepository;
        }

        public async Task<Guid> AddAsync(Guid userId, GoodsStockEntity entity)
        {
            entity.UserId = userId;
            return await _dkmsRepository.AddAsync(entity);
        }

        public async Task<int> ChangeStockAsync(Guid userId, Guid goodsId, decimal stock)
        {
            var goods = await _dkmsRepository.FirstAsync<GoodsStockEntity>(s => s.UserId == userId && s.GoodsId == goodsId);
            goods.Stock = goods.Stock + stock;
            return await _dkmsRepository.DbContext.SaveChangesAsync();
        }

        public async Task<List<GoodsStockEntity>> GetListAsync(Guid userId, IEnumerable<Guid> goodsIds)
        {
            return await _dkmsRepository.GetListAsync<GoodsStockEntity>(s => s.UserId == userId && goodsIds.Contains(s.GoodsId));
        }
    }
}
