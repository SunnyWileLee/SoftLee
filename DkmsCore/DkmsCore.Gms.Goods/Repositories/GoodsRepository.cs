using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;

namespace DkmsCore.Gms.Goods.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly IDkmsRepository _dkmsRepository;

        public GoodsRepository(IDkmsRepository dkmsRepository)
        {
            _dkmsRepository = dkmsRepository;
        }

        public async Task<Guid> AddAsync(Guid userId, GoodsEntity goods)
        {
            goods.UserId = userId;
            return await _dkmsRepository.AddAsync(goods);
        }

        public async Task<DkmsPage<GoodsEntity>> GetPageAsync(Guid userId, DkmsPageQuery query)
        {
            return await _dkmsRepository.GetPageAsync<GoodsEntity>(s => s.UserId == userId, query);
        }
    }
}
