using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    public class GoodsStockHistoryPageQuery : DkmsPageQuery
    {
        public Guid UserId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public Expression<Func<GoodsStockHistoryEntity, bool>> BuildPredicate()
        {
            return s => s.CreateTime > BeginTime && s.CreateTime < EndTime && s.UserId == UserId;
        }

        public Expression<Func<GoodsStockHistoryEntity, DateTime>> BuildOrderBy()
        {
            return s => s.CreateTime;
        }
    }
}
