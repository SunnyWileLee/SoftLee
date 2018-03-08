using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public class PageCollection<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> List { get; set; }
        public int Count { get; set; }
        public int PageCounts
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
