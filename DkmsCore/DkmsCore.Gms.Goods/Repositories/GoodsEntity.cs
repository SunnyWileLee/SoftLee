using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Goods.Repositories
{
    [Table("Goods")]
    public class GoodsEntity : DkmsStateableEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
