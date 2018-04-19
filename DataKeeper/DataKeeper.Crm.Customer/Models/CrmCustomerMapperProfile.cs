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
    public class CrmCustomerMapperProfile : Profile, IMapperProfile
    {
        public CrmCustomerMapperProfile()
        {
            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<CustomerModel, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerNaiveModel>();
        }

        public Profile GetProfile()
        {
            return new CrmCustomerMapperProfile();
        }
    }
}
