using AutoMapper;
using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Models
{
    class CustomerMapperProfile : MapperProfile, IMapperProfile
    {
        public CustomerMapperProfile()
        {
            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<CustomerEntity, CustomerNaiveModel>();
            CreateMap<CustomerModel, CustomerEntity>();
        }
    }
}
