using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DataKeeper.Framework.Models
{
    class MapperProfileProvider : IMapperProfileProvider
    {
        private readonly IMapperProfile[] _mapperProfiles;

        public MapperProfileProvider(IMapperProfile[] mapperProfiles)
        {
            _mapperProfiles = mapperProfiles;
        }

        public List<Profile> Provide()
        {
            if (_mapperProfiles == null || !_mapperProfiles.Any())
            {
                return new List<Profile> { };
            }
            return _mapperProfiles.Select(profile =>
            {
                return profile.GetProfile();
            }).ToList();
        }
    }
}
