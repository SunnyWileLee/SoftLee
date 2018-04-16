using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Entities;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Entities;

namespace DataKeeper.Framework.Applications
{
    public class EntityQueryService<TEntity> : IEntityQueryService<TEntity>
        where TEntity : UserEntity
    {
        private readonly IRepositoryProviderProvider _repositoryProviderProvider;
        private readonly IDbContextProvider _contextProvider;

        public EntityQueryService(IRepositoryProviderProvider repositoryProviderProvider,
                                     IDbContextProvider contextProvider)
        {
            _repositoryProviderProvider = repositoryProviderProvider;
            _contextProvider = contextProvider;
        }

        public IRepositoryProviderProvider RepositoryProviderProvider
        {
            get
            {
                return _repositoryProviderProvider;
            }
        }

        public IDbContextProvider ContextProvider
        {
            get
            {
                return _contextProvider;
            }
        }

        public virtual PageCollection<TModel> Page<TModel>(PageQueryParas<TEntity> pageQueryParas)
        {
            var repository = _repositoryProviderProvider.Provide<IEntityQueryRepository>().Provide();
            var context = CreatePageQueryContext(pageQueryParas);
            var entities = repository.Page(context);
            var models = Mapper.Map<List<TModel>>(entities.List);
            return new PageCollection<TModel>
            {
                PageSize = entities.PageSize,
                Count = entities.Count,
                List = models,
                Page = entities.Page
            };
        }

        protected QueryEntityPageContext<TEntity> CreatePageQueryContext(PageQueryParas<TEntity> pageQueryParas)
        {
            return new QueryEntityPageContext<TEntity>
            {
                ContextProvider = _contextProvider,
                PageQueryParas = pageQueryParas,
                UserId = UserContext.Current.UserId,
                Predicate = pageQueryParas.CreatePredicate()
            };
        }

        public virtual List<TModel> Query<TModel>(QueryParameter<TEntity> queryParas)
        {
            var repository = _repositoryProviderProvider.Provide<IEntityQueryRepository>().Provide();
            var context = CreateQueryContext(queryParas);
            var entities = repository.Query(context);
            var models = Mapper.Map<List<TModel>>(entities);
            return models;
        }

        protected QueryEntityContext<TEntity> CreateQueryContext(QueryParameter<TEntity> pageQueryParas)
        {
            return new QueryEntityContext<TEntity>
            {
                ContextProvider = _contextProvider,
                UserId = UserContext.Current.UserId,
                Predicate = pageQueryParas.CreatePredicate()
            };
        }
    }
}
