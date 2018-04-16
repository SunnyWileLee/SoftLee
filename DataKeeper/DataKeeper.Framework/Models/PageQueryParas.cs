﻿using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public class PageQueryParas<TEntity> : QueryParameter<TEntity>
        where TEntity : UserEntity
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
