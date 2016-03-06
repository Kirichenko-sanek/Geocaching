using AutoMapper;
using Geocaching.Core;
using Geocaching.ViewModels;

namespace Geocaching
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {

            Mapper.CreateMap<User, RegisterViewModel>();
           
            
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
                m.IdCache = p.id;
                m.IdUserCache = p.id_user;
                m.Name = p.name;
                m.Description = p.description;
                m.DateOfApperance = p.date_of_apperance;
                m.DateOfLastVisit = p.date_of_last_visit;
                m.UserName = p.user.first_name + " " + p.user.last_name;
                m.Longitude = p.address.longitude;
                m.Latitude = p.address.latitude;
                m.Country = p.address.country;
                m.Region = p.address.region;
                m.City = p.address.city;
            });

            Mapper.CreateMap<PhotoOfCaches, PhotoOfCachesViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.photo.id;
                m.Name = p.photo.name;
                m.Date = p.photo.date;
            });
        }
    }
}