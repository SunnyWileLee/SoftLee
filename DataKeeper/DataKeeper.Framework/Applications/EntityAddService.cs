using AutoMapper;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Applications
{
    class EntityAddService<TEntity> : IEntityAddService<TEntity>
        where TEntity : UserEntity
    {
        private readonly IEntityAddRepositoryProvider _entityAddRepositoryProvider;
        private readonly IDbContextProvider _contextProvider;

        public Guid Add<TModel>(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            var context = new AddEntityContext<TEntity>
            {
                ContextProvider = this._contextProvider,
                Entity = entity,
                UserId = UserContext.Current.UserId
            };
            var repository = _entityAddRepositoryProvider.Provide();
            var id = repository.Add<TEntity>(context);
            return id;
        }
    }
}
