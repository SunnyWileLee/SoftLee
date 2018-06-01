using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Ums.User.Entities;
using Dkms.Repository;

namespace DataKeeper.Ums.User.Repositories
{
    class TokenRepository : ITokenRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public TokenRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public void AddToken(TokenEntity token)
        {
            using (var context = _contextProvider.Provide<UserDbContext>())
            {
                context.Set<TokenEntity>().Add(token);
                context.SaveChanges();
            }
        }

        public TokenEntity GetToken(Guid token)
        {
            using (var context = _contextProvider.Provide<UserDbContext>())
            {
                var tokens = context.Set<TokenEntity>();
                return tokens.FirstOrDefault(s => s.Token == token);
            }
        }

        public void Refresh(Guid token)
        {
            using (var context = _contextProvider.Provide<UserDbContext>())
            {
                var entity = context.Set<TokenEntity>().FirstOrDefault(s => s.Token == token);
                if (entity == null)
                {
                    return;
                }
                entity.LastUsed = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
