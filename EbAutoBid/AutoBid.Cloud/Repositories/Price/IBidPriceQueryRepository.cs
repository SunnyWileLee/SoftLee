using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Cloud.Repositories.Price
{
    interface IBidPriceQueryRepository
    {
        List<BidPriceEntity> GetList(Guid userId, string sn);
    }
}
