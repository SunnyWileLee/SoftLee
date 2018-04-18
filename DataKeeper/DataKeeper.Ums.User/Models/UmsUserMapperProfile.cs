using AutoMapper;
using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Entities;
using DataKeeper.Ums.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.Account.Models
{
    public class UmsUserMapperProfile : Profile, IMapperProfile
    {
        public UmsUserMapperProfile()
        {
            CreateMap<AccountEntity, AccountModel>();
            CreateMap<AccountModel, AccountEntity>();
        }

        public Profile GetProfile()
        {
            return new UmsUserMapperProfile();
        }
    }
}

