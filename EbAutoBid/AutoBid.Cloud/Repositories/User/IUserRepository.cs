using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Cloud.Repositories.User
{
    interface IUserRepository
    {
        void AddUser(UserEntity entity);
        void UpdateUser(UserEntity entity);
        void DeleteUser(Guid Id);
    }
}
