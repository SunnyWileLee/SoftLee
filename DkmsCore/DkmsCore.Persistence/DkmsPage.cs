using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DkmsCore.Persistence
{
    public class DkmsPage<TEntity> where TEntity : class
    {
        public DkmsPage()
        {
            List = new List<TEntity> { };
            PageSize = 20;
        }

        public List<TEntity> List { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Pages
        {
            get
            {
                return (int)Math.Ceiling(((decimal)Count / PageSize));
            }
        }
        public bool Any()
        {
            return List?.Any() ?? false;
        }
    }
}
