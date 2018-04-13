using AutoMapper;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Entities;
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
    public class PropertyQueryService<TPropertyEntity> : IPropertyQueryService<TPropertyEntity>
        where TPropertyEntity : PropertyEntity
    {
        private readonly IPropertyQueryRepositoryProvider _propertyQueryRepositoryProvider;
        private readonly IDbContextProvider _contextProvider;

        public PropertyQueryService(IPropertyQueryRepositoryProvider propertyQueryRepositoryProvider, 
                                    IDbContextProvider contextProvider)
        {
            _propertyQueryRepositoryProvider = propertyQueryRepositoryProvider;
            _contextProvider = contextProvider;
        }

        public TPropertyModel First<TPropertyModel>(Guid id)
        {
            var repository = _propertyQueryRepositoryProvider.Provide();
            var context = new QueryPropertyContext<TPropertyEntity>
            {
                ContextProvider = _contextProvider,
                Predicate = s => s.Id == id,
                UserId = UserContext.Current.UserId
            };
            var property = repository.First(context);
            return Mapper.Map<TPropertyModel>(property);
        }

        public List<TPropertyModel> Query<TPropertyModel>()
        {
            var repository = _propertyQueryRepositoryProvider.Provide();
            var context = new QueryPropertyContext<TPropertyEntity>
            {
                ContextProvider = _contextProvider,
                Predicate = s => true,
                UserId = UserContext.Current.UserId
            };
            var properties = repository.Query(context);
            return Mapper.Map<List<TPropertyModel>>(properties);
        }
    }
}
