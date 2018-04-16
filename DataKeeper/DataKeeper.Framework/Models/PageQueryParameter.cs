using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public class PageQueryParameter<TEntity> : QueryParameter<TEntity>
        where TEntity : BaseEntity
    {
        public PageQueryParameter()
        {
            Page = 1;
            PageSize = 20;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public int Skip
        {
            get
            {
                return (Page - 1) * PageSize;
            }
        }

        public int Take
        {
            get
            {
                return PageSize;
            }
        }
    }
}
