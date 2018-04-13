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
    class PropertyService<TPropertyEntity> : IPropertyService<TPropertyEntity>
        where TPropertyEntity : PropertyEntity
    {
        private readonly IPropertyAddRepositoryProvider _propertyAddRepository;
        private readonly IDbContextProvider _contextProvider;

        public PropertyService(IPropertyAddRepositoryProvider propertyAddRepository, 
                               IDbContextProvider contextProvider)
        {
            _propertyAddRepository = propertyAddRepository;
            _contextProvider = contextProvider;
        }

        public Guid Add<TPropertyModel>(TPropertyModel model) where TPropertyModel : PropertyModel
        {
            var repository = _propertyAddRepository.Provide();
            var property = Mapper.Map<TPropertyEntity>(model);
            var context = new AddPropertyContext<TPropertyEntity>
            {
                ContextProvider = _contextProvider,
                Property = property,
                UserId = UserContext.Current.UserId
            };
            return repository.Add(context);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update<TPropertyModel>(TPropertyModel model) where TPropertyModel : PropertyModel
        {
            throw new NotImplementedException();
        }
    }
}
