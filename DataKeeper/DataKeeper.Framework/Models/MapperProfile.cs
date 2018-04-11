using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DataKeeper.Framework.Models
{
    public abstract class MapperProfile : Profile, IMapperProfile
    {
        public virtual Profile GetProfile()
        {
            return Activator.CreateInstance(this.GetType()) as Profile;
        }
    }
}
