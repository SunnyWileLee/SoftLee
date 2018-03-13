using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Models;
using DataKeeper.Ums.User.Repositories;

namespace DataKeeper.Ums.User.Applications
{
    class AccountQueryService : IAccountQueryService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;

        public AccountQueryService(ITokenRepository tokenRepository, 
                                   IAccountQueryRepository accountQueryRepository)
        {
            _tokenRepository = tokenRepository;
            _accountQueryRepository = accountQueryRepository;
        }

        public AccountModel GetByToken(Guid token)
        {
            var tokenEntity = _tokenRepository.GetToken(token);
            if (tokenEntity == null || !tokenEntity.IsValid)
            {
                return null;
            }
            var account = _accountQueryRepository.GetById(tokenEntity.UserId);
            return Mapper.Map<AccountModel>(account);
        }

        public PageCollection<AccountModel> Page(AccountPageQueryParas paras)
        {
            throw new NotImplementedException();
        }
    }
}
