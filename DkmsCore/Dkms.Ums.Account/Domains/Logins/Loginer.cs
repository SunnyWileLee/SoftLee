using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dkms.Ums.Account.Domains.Tokens;
using Dkms.Ums.Account.Repositories;
using DkmsCore.Infrustructure.Webs;
using DkmsCore.Persistence.Repositories;

namespace Dkms.Ums.Account.Domains.Logins
{
    public class Loginer : ILoginer
    {
        private readonly IDkmsRepository _dkmsRepository;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IPasswordFactory _passwordFactory;

        public Loginer(IDkmsRepository dkmsRepository, ITokenBuilder tokenBuilder, IPasswordFactory passwordFactory)
        {
            _dkmsRepository = dkmsRepository;
            _tokenBuilder = tokenBuilder;
            _passwordFactory = passwordFactory;
        }

        public async Task<string> LoginAsync(AccountEntity parameters)
        {
            var account = await _dkmsRepository.FirstAsync<AccountEntity>(s => s.Phone == parameters.Phone);
            if (account == null)
            {
                throw new DkmsException("用户名或密码错误");
            }
            if (!_passwordFactory.VerifyPassword(account, parameters.Password))
            {
                throw new DkmsException("用户名或密码错误");
            }
            var tokenString = _tokenBuilder.Build();
            var token = new TokenEntity
            {
                Token = tokenString,
                UserId = account.Id
            };
            await _dkmsRepository.AddAsync(token);
            return tokenString;
        }
    }
}
