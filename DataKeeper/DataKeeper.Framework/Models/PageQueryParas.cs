using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public class PageQueryParas
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int Skip
        {
            get
            {
                return (Page - 1) * PageSize;
            }
        }
    }
}
