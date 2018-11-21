using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Goods.Repositories
{
    public interface IGoodsRepository
    {
        Task<Guid> AddAsync(Guid userId, GoodsEntity goods);
        Task<DkmsPage<GoodsEntity>> GetPageAsync(Guid userId, DkmsPageQuery query);
    }
}
