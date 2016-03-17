using System;
using System.Collections.Generic;
using AutoMapper;
using Geocaching.Core;
using Geocaching.ViewModels;

namespace Geocaching
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {                           
            Mapper.CreateMap<RegisterViewModel, User>().AfterMap((p, m) =>
                {
                    m.first_name = p.FirstName;
                    m.last_name = p.LastName;
                    m.email = p.Email;
                });

            Mapper.CreateMap<User, UserPageViewModel>().AfterMap((p, m) =>
            {
                m.Name = p.first_name + " " + p.last_name;
                m.IdUserPage = p.id;
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

            Mapper.CreateMap<Comment, CommentsViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.id;
                m.IdUser = p.id_user;
                m.IdCache = p.id_cache;
                m.UserName = p.user.first_name + " " + p.user.last_name;
                m.Description = p.description;
                m.Date = p.date;
            });
            Mapper.CreateMap<CachePageViewModel, Comment>().AfterMap((p, m) =>
            {
                m.id_cache = p.IdCache;
                m.id_user = p.IdUserInSystem;
                m.description = p.NewComment;
                m.date = DateTime.Now;
            });

            Mapper.CreateMap<CachePageViewModel, ListOfVisitedCaches>().AfterMap((p, m) =>
            {
                m.id_cache = p.IdCache;
                m.date = DateTime.Now;
            });

            Mapper.CreateMap<ListOfVisitedCaches, CacheViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.id_cache;
                m.CacheName = p.cache.name;
                m.IdUserCache = p.cache.id_user;
                m.DateVisit = p.date;
                m.DateAdded = p.cache.date_of_apperance;
                m.UserName = p.cache.user.first_name + " " + p.cache.user.last_name;
                
            });

            Mapper.CreateMap<Cache, CacheViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.id;
                m.CacheName = p.name;
                m.IdUserCache = p.id_user;
                m.DateVisit = p.date_of_last_visit;
                m.DateAdded = p.date_of_apperance;
                m.UserName = p.user.first_name + " " + p.user.last_name;
            });

            Mapper.CreateMap<User, EditProfileViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.id;
                m.FirstName = p.first_name;
                m.LastName = p.last_name;
                m.Email = p.email;
            });

            Mapper.CreateMap<EditProfileViewModel, User>().AfterMap((p, m) =>
            {
                m.first_name = p.FirstName;
                m.last_name = p.LastName;
                m.email = p.Email;
            });

            Mapper.CreateMap<AddCacheViewModel, Cache>().AfterMap((p, m) =>
            {
                m.id_user = p.IdUser;
                m.name = p.Name;
                m.description = p.Description;
                m.date_of_apperance = DateTime.Now;
                m.date_of_last_visit = DateTime.Now;
                m.address = new Address
                {
                    longitude = p.Longitude,
                    latitude = p.Latitude,
                    country = p.Country,
                    region = p.Region,
                    city = p.City,
                };               
            });

            Mapper.CreateMap<AddCacheViewModel, Address>().AfterMap((p, m) =>
            {
                m.country = p.Country;
                m.region = p.Region;
                m.city = p.City;
            });

            
        }
    }
}