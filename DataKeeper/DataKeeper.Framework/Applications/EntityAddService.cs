using AutoMapper;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Entities;
using DataKeeper.Framework.Repositories.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    class EntityAddService<TEntity, TPropertyValueEntity> : IEntityAddService<TEntity, TPropertyValueEntity>
        where TEntity : UserEntity
        where TPropertyValueEntity : PropertyValueEntity
    {
        private readonly IEntityAddRepositoryProvider _entityAddRepositoryProvider;
        private readonly IDbContextProvider _contextProvider;
        private readonly IRepositoryProviderProvider _repositoryProviderProvider;
        private readonly IPropertyValueKeyProviderSelector _propertyValueKeyProviderSelector;

        public EntityAddService(IEntityAddRepositoryProvider entityAddRepositoryProvider,
                                IDbContextProvider contextProvider,
                                IRepositoryProviderProvider repositoryProviderProvider,
                                IPropertyValueKeyProviderSelector propertyValueKeyProviderSelector)
        {
            _entityAddRepositoryProvider = entityAddRepositoryProvider;
            _contextProvider = contextProvider;
            _repositoryProviderProvider = repositoryProviderProvider;
            _propertyValueKeyProviderSelector = propertyValueKeyProviderSelector;
        }

        public Guid Add<TModel>(TModel model) where TModel : PropertyOwnerModel
        {
            var entity = Mapper.Map<TEntity>(model);
            var values = Mapper.Map<List<TPropertyValueEntity>>(model.Properties.ToList());
            var userId = UserContext.Current.UserId;
            var context = new AddPropertyOwnerContext<TEntity, TPropertyValueEntity>
            {
                ContextProvider = this._contextProvider,
                Entity = entity,
                UserId = userId,
                Values = values
            };
            var repository = _entityAddRepositoryProvider.Provide();
            repository.SuccessEvent += AddEntity_SuccessEvent;
            return repository.Add(context);
        }

        private void AddEntity_SuccessEvent(object sender, RepositoryEventArgs args)
        {
            if (args.NewEntityId == Guid.Empty)
            {
                throw new ArgumentNullException("AddEntity_SuccessEvent=>EntityId");
            }
            var context = args.AccessDbContext as AddPropertyOwnerContext<TEntity, TPropertyValueEntity>;
            if (context == null)
            {
                return;
            }
            var values = context.Values.ToList();
            values.ForEach(value =>
            {
                value.UserId = context.UserId;
                value.SetInstance(args.NewEntityId);
            });
            var valueContext = new SetPropertyValueContext<TPropertyValueEntity>
            {
                ContextProvider = _contextProvider,
                InstanceId = args.NewEntityId,
                KeyProperty = _propertyValueKeyProviderSelector.Select().Provide<TPropertyValueEntity>(),
                UserId = context.UserId,
                PropertyValues = values
            };
            _repositoryProviderProvider.Provide<IPropertyValueSetRepository>().Provide().SetValues(valueContext);
        }
    }
}
