using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Entities;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Entities;
using DataKeeper.Framework.Repositories.Properties;

namespace DataKeeper.Framework.Applications
{
    public class EntityQueryService<TEntity, TPropertyValueEntity> : IEntityQueryService<TEntity, TPropertyValueEntity>
        where TEntity : UserEntity
        where TPropertyValueEntity : PropertyValueEntity
    {
        private readonly IRepositoryProviderProvider _repositoryProviderProvider;
        private readonly IDbContextProvider _contextProvider;
        private readonly IPropertyValueKeyProviderSelector _propertyValueKeyProviderSelector;

        public EntityQueryService(IRepositoryProviderProvider repositoryProviderProvider,
                                  IPropertyValueKeyProviderSelector propertyValueKeyProviderSelector,
                                  IDbContextProviderSelector dbContextProviderSelector)
        {
            _repositoryProviderProvider = repositoryProviderProvider;
            _contextProvider = dbContextProviderSelector.Select<TEntity>();
            _propertyValueKeyProviderSelector = propertyValueKeyProviderSelector;
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

        public virtual PageCollection<TModel> Page<TModel>(PageQueryParameter<TEntity> parameter) 
            where TModel : PropertyOwnerModel<TPropertyValueEntity>
        {
            var repository = _repositoryProviderProvider.Provide<IEntityQueryRepository>().Provide();
            var context = CreatePageQueryContext(parameter);
            var entities = repository.Page(context);
            var models = Mapper.Map<List<TModel>>(entities.List);
            var valueRepository = _repositoryProviderProvider.Provide<IPropertyValueQueryRepository>().Provide();
            var valueContext = new GroupPropertyValueContext<TPropertyValueEntity>
            {
                ContextProvider = _contextProvider,
                Keys = entities.List.Select(s => s.Id).ToList(),
                PropertyValueKeyProvider = _propertyValueKeyProviderSelector.Select(),
                UserId = UserContext.Current.UserId
            };
            var values = valueRepository.Grouping(valueContext);
            models.ForEach(model =>
            {
                var vs = values.FirstOrDefault(x => x.Key == model.Id);
                if (vs == null)
                {
                    return;
                }
                model.Properties = vs?.ToList();
            });
            return new PageCollection<TModel>
            {
                PageSize = entities.PageSize,
                Count = entities.Count,
                List = models,
                Page = entities.Page
            };
        }

        protected QueryEntityPageContext<TEntity> CreatePageQueryContext(PageQueryParameter<TEntity> parameter)
        {
            return new QueryEntityPageContext<TEntity>
            {
                ContextProvider = _contextProvider,
                PageQueryParas = parameter,
                UserId = UserContext.Current.UserId,
                Predicate = parameter.CreatePredicate()
            };
        }

        public virtual List<TModel> Query<TModel>(QueryParameter<TEntity> parameter)
        {
            var repository = _repositoryProviderProvider.Provide<IEntityQueryRepository>().Provide();
            var context = CreateQueryContext(parameter);
            var entities = repository.Query(context);
            var models = Mapper.Map<List<TModel>>(entities);
            return models;
        }

        protected QueryEntityContext<TEntity> CreateQueryContext(QueryParameter<TEntity> parameter)
        {
            return new QueryEntityContext<TEntity>
            {
                ContextProvider = _contextProvider,
                UserId = UserContext.Current.UserId,
                Predicate = parameter.CreatePredicate()
            };
        }
    }
}
