using DkmsCore.Oms.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Oms.Order.Domains
{
    interface IOrdersKeeper
    {
        Task<Guid> AddAsync(OrdersModel model);
    }
}
