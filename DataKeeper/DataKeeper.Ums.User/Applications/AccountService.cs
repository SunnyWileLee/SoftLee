using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Infrustructure.Utilities;
using DataKeeper.Ums.User.Entities;
using DataKeeper.Ums.User.Models;
using DataKeeper.Ums.User.Repositories;

namespace DataKeeper.Ums.User.Applications
{
    class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IMd5Encrypter _md5Encrypter;
        private readonly ITokenRepository _tokenRepository;

        public AccountService(IAccountRepository accountRepository,
                              IAccountQueryRepository accountQueryRepository,
                              IMd5Encrypter md5Encrypter,
                              ITokenRepository tokenRepository)
        {
            _accountRepository = accountRepository;
            _accountQueryRepository = accountQueryRepository;
            _md5Encrypter = md5Encrypter;
            _tokenRepository = tokenRepository;
        }

        public Guid AddAccount(AccountModel model)
        {
            var account = Mapper.Map<AccountEntity>(model);
            account.Password = _md5Encrypter.Encrypt(model.Password);
            return _accountRepository.AddAccount(account);
        }

        public Guid Signin(AccountModel model)
        {
            if (string.IsNullOrEmpty(model.Phone) || string.IsNullOrEmpty(model.Password))
            {
                return Guid.Empty;
            }
            var account = _accountQueryRepository.GetByPhone(model.Phone);
            if (account == null)
            {
                return Guid.Empty;
            }
            if (_md5Encrypter.Encrypt(model.Password).Equals(account.Password))
            {
                var token = Guid.NewGuid();
                Task.Run(() =>
                {
                    _tokenRepository.AddToken(new TokenEntity { Token = token, IsValid = true });
                });
                return token;
            }
            return Guid.Empty;
        }
    }
}
