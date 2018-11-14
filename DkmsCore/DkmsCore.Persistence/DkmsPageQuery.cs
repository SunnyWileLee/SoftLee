using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Persistence
{
    public class DkmsPageQuery : DkmsQuery
    {
        public const int DefaultPageIndex = 1;
        public const int DefaultPageSize = 20;

        public DkmsPageQuery()
        {
            PageIndex = DefaultPageIndex;
            PageSize = DefaultPageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int Skip
        {
            get
            {
                return (PageIndex - 1) * PageSize;
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
