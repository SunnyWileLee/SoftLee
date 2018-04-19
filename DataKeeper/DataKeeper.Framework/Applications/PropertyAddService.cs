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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    public class PropertyAddService<TPropertyEntity> : IPropertyAddService<TPropertyEntity>
        where TPropertyEntity : PropertyEntity
    {
        private readonly IRepositoryProviderProvider _repositoryProviderProvider;       
        private readonly IDbContextProvider _contextProvider;

        public PropertyAddService(IRepositoryProviderProvider repositoryProviderProvider,
                                  IDbContextProviderSelector dbContextProviderSelector)
        {
            _repositoryProviderProvider = repositoryProviderProvider;
            _contextProvider = dbContextProviderSelector.Select<TPropertyEntity>();
        }

        public Guid Add(TPropertyEntity model) 
        {
            var repository = _repositoryProviderProvider.Provide<IPropertyAddRepository>().Provide();
            var property = Mapper.Map<TPropertyEntity>(model);
            var context = new AddPropertyContext<TPropertyEntity>
            {
                ContextProvider = _contextProvider,
                Property = property,
                UserId = UserContext.Current.UserId
            };
            return repository.Add(context);
        }
    }
}
