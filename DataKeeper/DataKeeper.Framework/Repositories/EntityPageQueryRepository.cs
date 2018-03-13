﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;

namespace DataKeeper.Framework.Repositories
{
    public class EntityPageQueryRepository : IEntityPageQueryRepository
    {
        public virtual PageCollection<TEntity> Page<TEntity>(EntityPageQueryContext<TEntity> context) where TEntity : UserEntity
        {
            using (var db = context.ContextProvider.Provide())
            {
                var entities = db.Set<TEntity>()
                                 .Where(s => s.UserId == context.UserId)
                                 .Where(context.Predicate);
                var count = entities.Count();
                var list = entities.OrderByDescending(s => s.CreateTime)
                                   .Skip(context.PageQueryParas.Skip)
                                   .Take(context.PageQueryParas.PageSize)
                                   .ToList();
                return new PageCollection<TEntity>
                {
                    PageSize = context.PageQueryParas.PageSize,
                    Count = count,
                    List = list,
                    Page = context.PageQueryParas.Page
                };
            }
        }
    }
}
