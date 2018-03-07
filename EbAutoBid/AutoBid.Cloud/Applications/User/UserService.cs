using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoBid.Cloud.Models.User;
using AutoBid.Cloud.Repositories.User;

namespace AutoBid.Cloud.Applications.User
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public void AddUser(AddUserParas paras)
        {
            var entity = new UserEntity
            {
                Name = paras.Name,
                UserId = paras.UserId
            };
            _userRepository.AddUser(entity);
        }

        public void DeleteUser(Guid Id)
        {
            _userRepository.DeleteUser(Id);
        }

        public void UpdateUser(EditUserParas paras)
        {
            var entity = new UserEntity
            {
                Id = paras.Id,
                Name = paras.Name
            };
            _userRepository.UpdateUser(entity);
        }
    }
}