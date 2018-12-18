using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Oms.Order.Repositories
{
    [Table("Orders")]
    public class OrdersEntity : DkmsUserEntity
    {
        [MaxLength(50)]
        public string OrderCode { get; set; }
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GoodsId { get; set; }
        [MaxLength(500)]
        public string Memo { get; set; }
    }
}
