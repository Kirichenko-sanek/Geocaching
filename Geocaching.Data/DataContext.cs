﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using Geocaching.Core;
using Geocaching.BL;
using Geocaching.Data.Mapping;


namespace Geocaching.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Cache> Caches { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ListOfVisitedCaches> ListOfVisitedCaches { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoOfCaches> PhotoOfCaches { get; set; }
        public DbSet<PhotoOfUser> PhotoOfUser { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInRoles> UserInRoles { get; set; }

        public DataContext() : base ("GeocachingDB")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new GeocachingInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CacheMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new ListOfVisitedCachesMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new PhotoOfCachesMap());
            modelBuilder.Configurations.Add(new PhotoOfUserMap());
            modelBuilder.Configurations.Add(new RolesMap());
            modelBuilder.Configurations.Add(new UserInRolesMap());
            modelBuilder.Configurations.Add(new UserMap());

        }

        private class GeocachingInitializer : CreateDatabaseIfNotExists<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                var roles = new List<Roles>
                {
                    new Roles()
                    {
                        name = "Admin"
                    },
                    new Roles()
                    {
                        name = "User"
                    }
                };
                foreach (var role in roles) context.Roles.Add(role);
                context.SaveChanges();


                var salt = PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.HashPassword("123456", salt);
                var useres = new List<User>
                {
                    new User()
                    {
                        first_name = "Kirichenko",
                        last_name = "Alexander",
                        email = "kirichenko-sanek@mail.ru",
                        password = pass,           
                        password_salt = salt,
                        is_activated = true,
                        is_deleted = false,
                        users = new List<UserInRoles>() {new UserInRoles() {id_roles = 1, id_user = 1}}
                    },
                    new User()
                    {
                        first_name = "Serkov",
                        last_name = "Sergei",
                        email = "Serkov@ser.ru",
                        password = pass,
                        password_salt = salt,
                        is_activated = true,
                        is_deleted = false,
                        users = new List<UserInRoles>() {new UserInRoles() {id_roles = 2, id_user = 1}}
                    }
                };
                foreach (var user in useres) context.Users.Add(user);
                context.SaveChanges();

                var photos = new List<Photo>
                {
                    new Photo()
                    {
                        name = "/Images/Account/images.jpg",
                        date = DateTime.Now
                    },
                    new Photo()
                    {
                        name = "/Images/Cache/1.jpg",
                        date = DateTime.Now
                    },
                    new Photo()
                    {
                        name = "/Images/Cache/2.jpg",
                        date = DateTime.Now
                    },
                    new Photo()
                    {
                        name = "/Images/Account/11.jpg",
                        date = DateTime.Now
                    },
                    new Photo()
                    {
                        name = "/Images/Account/22.jpg",
                        date = DateTime.Now
                    },
                    new Photo()
                    {
                        name = "/Images/Cache/3.jpg",
                        date = DateTime.Now
                    },

                };
                foreach (var photo in photos) context.Photos.Add(photo);
                context.SaveChanges();

                var photosOfUser = new List<PhotoOfUser>
                {
                    new PhotoOfUser()
                    {
                        id_user = 1,
                        id_photo = 1,
                        main_photo = true
                    },
                    new PhotoOfUser()
                    {
                        id_user = 2,
                        id_photo = 1,
                        main_photo = true
                    },
                    new PhotoOfUser()
                    {
                        id_user = 1,
                        id_photo = 4
                    },
                    new PhotoOfUser()
                    {
                        id_user = 1,
                        id_photo = 5
                    }
                };
                foreach (var photoUser in photosOfUser) context.PhotoOfUser.Add(photoUser);
                context.SaveChanges();

                var addresses = new List<Address>
                {
                    new Address()
                    {
                        longitude = 36.290417,
                        latitude = 50.042919,
                        country = "Ukraine",
                        region = "Kharkov region",
                        city = "Kharkiv"
                    },
                    new Address()
                    {
                        longitude = 36.2913754,
                        latitude = 50.04302158,
                        country = "Ukraine",
                        region = "Kharkov region",
                        city = "Kharkiv"
                    }
                };
                foreach (var address in addresses) context.Address.Add(address);
                context.SaveChanges();

                var caches = new List<Cache>
                {
                    new Cache()
                    {
                        id_user = 1,
                        id_address = 1,
                        name = "KHAI",
                        description = "Контейнер расположен под правым колесом самолёта. Внутри контейнера находятся небольшие предметы для обмена. Внутри контейнера есть блокнот и карандаш. Приятного приключения))",
                        date_of_apperance = DateTime.Now,
                        date_of_last_visit = DateTime.Now,                     
                    },
                    new Cache()
                    {
                        id_user = 2,
                        id_address = 2,
                        name = "KHAI",
                        description = "Тайник расположен в холе радио корпуса. Распологается в третьем слева горшке для цветов. Внутри ты найдёш пластиклвый контейнер с приятным сюрпризом. Не забудь оставить что  нибуть на память",
                        date_of_apperance = DateTime.Now,
                        date_of_last_visit = DateTime.Now,
                    }
                };
                foreach (var cache in caches) context.Caches.Add(cache);
                context.SaveChanges();

                var photosOfCaches = new List<PhotoOfCaches>
                {
                    new PhotoOfCaches()
                    {
                        id_cache = 1,
                        id_photo = 2
                    },
                    new PhotoOfCaches()
                    {
                        id_cache = 1,
                        id_photo = 3
                    },
                    new PhotoOfCaches()
                    {
                        id_cache = 2,
                        id_photo = 6
                    }
                };
                foreach (var photoCache in photosOfCaches) context.PhotoOfCaches.Add(photoCache);
                context.SaveChanges();

                var comments = new List<Comment>
                {
                    new Comment()
                    {
                        id_user = 2,
                        id_cache = 1,
                        description = "Отличный тайник.",
                        date = DateTime.Now
                    },
                    new Comment()
                    {
                        id_user = 1,
                        id_cache = 1,
                        description = "Не забываёте отмечаться в блокноте)",
                        date = DateTime.Now
                    },
                };
                foreach (var coment in comments) context.Comments.Add(coment);
                context.SaveChanges();

                var listOfVisitedCache = new List<ListOfVisitedCaches>
                {
                    new ListOfVisitedCaches()
                    {
                        id_user = 1,
                        id_cache = 1,
                        date = DateTime.Now
                    },
                    new ListOfVisitedCaches()
                    {
                        id_user = 1,
                        id_cache = 2,
                        date = DateTime.Now
                    }
                };
                foreach (var list in listOfVisitedCache) context.ListOfVisitedCaches.Add(list);
                context.SaveChanges();
               

                base.Seed(context);
            }
        }
    }
}
