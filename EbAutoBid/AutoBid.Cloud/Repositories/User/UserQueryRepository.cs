using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories.User
{
    class UserQueryRepository : IUserQueryRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        public UserQueryRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public List<UserEntity> GetList()
        {
            using (var context = _dbContextProvider.Provide())
            {
                return context.Users.ToList();
            }
        }
    }
}