using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;

namespace DataKeeper.Framework.Applications
{
    public abstract class EntityQueryService<TEntity> : IEntityQueryService<TEntity>
        where TEntity : UserEntity
    {
        private readonly IEntityQueryRepositoryProvider _entityPageQueryRepositoryProvider;
        private readonly IDbContextProvider _contextProvider;

        protected EntityQueryService(IEntityQueryRepositoryProvider entityPageQueryRepositoryProvider,
                                     IDbContextProvider contextProvider)
        {
            _entityPageQueryRepositoryProvider = entityPageQueryRepositoryProvider;
            _contextProvider = contextProvider;
        }

        public IEntityQueryRepositoryProvider EntityPageQueryRepositoryProvider
        {
            get
            {
                return _entityPageQueryRepositoryProvider;
            }
        }

        public IDbContextProvider ContextProvider
        {
            get
            {
                return _contextProvider;
            }
        }

        public virtual PageCollection<TModel> Page<TModel>(PageQueryParas pageQueryParas)
        {
            var entityPageQueryRepository = _entityPageQueryRepositoryProvider.Provide();
            var context = CreatePageContext(pageQueryParas);
            var entities = entityPageQueryRepository.Page(context);
            var models = Mapper.Map<List<TModel>>(entities.List);
            return new PageCollection<TModel>
            {
                PageSize = entities.PageSize,
                Count = entities.Count,
                List = models,
                Page = entities.Page
            };
        }

        protected virtual QueryEntityPageContext<TEntity> CreatePageContext(PageQueryParas pageQueryParas)
        {
            return new QueryEntityPageContext<TEntity>
            {
                ContextProvider = _contextProvider,
                PageQueryParas = pageQueryParas,
                UserId = UserContext.Current.UserId,
                Predicate = s => true
            };
        }

        public virtual List<TModel> Query<TModel>(QueryParas queryParas)
        {
            throw new NotImplementedException();
        }
    }
}
