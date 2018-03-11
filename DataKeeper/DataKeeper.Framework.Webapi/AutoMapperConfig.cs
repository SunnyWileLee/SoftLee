using AutoMapper;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Webapi
{
    public static class AutoMapperConfig
    {
        public static void Config(IMapperProfileProvider profileProvider)
        {
            Mapper.Initialize(cfg =>
            {
                var profies = profileProvider.Provide();
                profies.ForEach(profile =>
                {
                    cfg.AddProfile(profile);//添加一个配置文件
                });
            });
        }
    }
}
