﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    interface IGoodsStockReasonRepository
    {
        Task<List<GoodsStockReasonEntity>> GetListAsync(Guid userId);
        Task<Guid> AddAsync(Guid userId, GoodsStockReasonEntity entity);
    }
}
