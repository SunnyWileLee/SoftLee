using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories.User
{
    class UserRepository : IUserRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        public UserRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public void AddUser(UserEntity entity)
        {
            using (var context = _dbContextProvider.Provide())
            {
                var users = context.Users;
                if (users.Any(s => s.UserId == entity.UserId))
                {
                    return;
                }
                users.Add(entity);
                context.SaveChanges();
            }
        }

        public void DeleteUser(Guid Id)
        {
            using (var context = _dbContextProvider.Provide())
            {
                var users = context.Users;
                var user = users.FirstOrDefault(s => s.Id == Id);
                if (user == null)
                {
                    return;
                }
                users.Remove(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(UserEntity entity)
        {
            using (var context = _dbContextProvider.Provide())
            {
                var users = context.Users;
                var user = users.FirstOrDefault(s => s.Id == entity.Id);
                if (user == null)
                {
                    return;
                }
                user.Name = entity.Name;
                context.SaveChanges();
            }
        }
    }
}