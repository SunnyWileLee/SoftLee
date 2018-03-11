using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Models
{
    public interface IMapperProfile
    {
        Profile GetProfile();
    }
}
