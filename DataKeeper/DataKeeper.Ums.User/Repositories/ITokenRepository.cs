using DataKeeper.Ums.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Repositories
{
    interface ITokenRepository
    {
        TokenEntity GetToken(Guid token);
        void AddToken(TokenEntity token);
        void Refresh(Guid token);
    }
}
