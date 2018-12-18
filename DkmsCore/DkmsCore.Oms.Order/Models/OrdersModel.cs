using DkmsCore.Oms.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Oms.Order.Models
{
    public class OrdersModel
    {
        public OrdersEntity Order { get; set; }
        public List<OrdersPropertyValueEntity> Values { get; set; } = new List<OrdersPropertyValueEntity> { };
    }
}
