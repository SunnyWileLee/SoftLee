using DkmsCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    public class GoodsStockReasonRepository : IGoodsStockReasonRepository
    {
        private readonly IDkmsRepository _dkmsRepository;

        public GoodsStockReasonRepository(IDkmsRepository dkmsRepository)
        {
            _dkmsRepository = dkmsRepository;
        }

        public async Task<Guid> AddAsync(Guid userId, GoodsStockReasonEntity entity)
        {
            entity.UserId = userId;
            return await _dkmsRepository.AddAsync(entity);
        }

        public async Task<List<GoodsStockReasonEntity>> GetListAsync(Guid userId)
        {
            return await _dkmsRepository.GetListAsync<GoodsStockReasonEntity>(s => s.UserId == userId);
        }
    }
}
