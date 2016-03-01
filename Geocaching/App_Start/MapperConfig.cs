using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using Geocaching.Core;
using Geocaching.Models;

namespace Geocaching.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {
            /*var registerMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, RegisterViewModel>();
            });*/


            Mapper.CreateMap<RegisterViewModel, User>().AfterMap((p, m) =>
                {
                    m.first_name = p.FirstName;
                    m.last_name = p.LastName;
                    m.email = p.Email;
                });
            
           





            Mapper.CreateMap<User, UserPageViewModel>().AfterMap((p, m) =>
            {
                m.Name = p.first_name + " " + p.last_name;
                m.IdUserInSystem = p.id;
            });

            Mapper.CreateMap<Cache, CachePageViewModel>().AfterMap((p, m) =>
            {

            });
        }
    }
}