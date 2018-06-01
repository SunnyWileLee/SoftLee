using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Properties;
using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public class PropertyDeleteService<TPropertyEntity, TPropertyValueEntity> : IPropertyDeleteService<TPropertyEntity, TPropertyValueEntity>
        where TPropertyEntity : PropertyEntity
        where TPropertyValueEntity : PropertyValueEntity
    {
        private readonly IRepositoryProviderProvider _repositoryProviderProvider;
        private readonly IPropertyValueKeyProviderSelector _propertyValueKeyProviderSelector;
        private readonly IDbContextProvider _contextProvider;

        public PropertyDeleteService(IRepositoryProviderProvider repositoryProviderProvider,
                                     IPropertyValueKeyProviderSelector propertyValueKeyProviderSelector,
                                     IDbContextProvider contextProvider)
        {
            _repositoryProviderProvider = repositoryProviderProvider;
            _propertyValueKeyProviderSelector = propertyValueKeyProviderSelector;
            _contextProvider = contextProvider;
        }

        public void Delete(Guid id)
        {
            var context = new DeletePropertyContext<TPropertyEntity>
            {
                ContextProvider = _contextProvider,
                Id = id,
                UserId = UserContext.Current.UserId
            };
            var repository = _repositoryProviderProvider.Provide<IPropertyDeleteRepository>().Provide();
            repository.SuccessEvent += DeleteProperty_SuccessEvent;
            repository.Delete(context);
        }

        private void DeleteProperty_SuccessEvent(object sender, RepositoryEventArgs args)
        {
            var successContext = args.AccessDbContext as DeletePropertyContext<TPropertyEntity>;
            var context = new DeletePropertyValueContext<TPropertyValueEntity>
            {
                ContextProvider = _contextProvider,
                InstanceId = successContext.Id,
                IsCancel = false,
                KeyProperty = _propertyValueKeyProviderSelector.Select().Provide<TPropertyValueEntity>(),
                UserId = UserContext.Current.UserId
            };
            var repository = _repositoryProviderProvider.Provide<IPropertyValueDeleteRepository>().Provide();
            repository.Delete(context);
        }
    }
}
