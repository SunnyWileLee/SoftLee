using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Applications
{
    public interface IAccountQueryService
    {
        AccountModel GetByToken(Guid token);
        PageCollection<AccountModel> Page(AccountPageQueryParas paras);
    }
}
