using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoBid.Cloud.Models.User;
using AutoBid.Cloud.Repositories.User;
using AutoMapper;

namespace AutoBid.Cloud.Applications.User
{
    class UserQueryService : IUserQueryService
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public UserQueryService(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public List<UserModel> GetUser()
        {
            var users = _userQueryRepository.GetList();
            return Mapper.Map<List<UserModel>>(users);
        }
    }
}