using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public class EntityPage<TEntity>
    {
        public List<TEntity> List { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Pages
        {
            get
            {
                return (int)Math.Ceiling(((decimal)Count / PageSize)); ;
            }
        }

        public bool Any()
        {
            return List != null && List.Any();
        }
    }
}
