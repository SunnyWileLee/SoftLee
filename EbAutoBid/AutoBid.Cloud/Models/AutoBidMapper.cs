using AutoBid.Cloud.Models.Price;
using AutoBid.Cloud.Models.User;
using AutoBid.Cloud.Repositories.Price;
using AutoBid.Cloud.Repositories.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models
{
    public class AutoBidMapper : Profile
    {
        public AutoBidMapper()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<BidPriceModel, BidPriceEntity>();
            CreateMap<BidPriceEntity, BidPriceModel>();
        }
    }
}