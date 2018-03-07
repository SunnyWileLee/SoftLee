using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Cloud.Repositories.User
{
    interface IUserQueryRepository
    {
        List<UserEntity> GetList();
    }
}
