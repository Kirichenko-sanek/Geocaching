using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Geocaching.BL.Manager;
using Geocaching.BL.Validators;
using Geocaching.Core;
using Geocaching.Data;
using Geocaching.Data.Repository;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;
using Microsoft.Practices.ServiceLocation;

namespace Geocaching.CW.Installers
{
    public class AdminInstaller : IWindsorInstaller
    {
        private const string WebAssemblyName = "Geocaching";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(WebAssemblyName)
                .BasedOn<IController>()
                .LifestyleTransient()
                .Configure(x => x.Named(x.Implementation.Name)));

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<WindsorControllerFactory>());

            container.Register(Component.For<DataContext>().LifestyleSingleton());
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());           
            container.Register(
                Component.For(typeof (IUserRepository<>)).ImplementedBy(typeof (UserRepository<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IPhotoOfUserRepository<>))
                    .ImplementedBy(typeof (PhotoOfUserRepository<>))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (ICacheRepository<>))
                    .ImplementedBy(typeof (CacheRepository<>))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IPhotoOfCachesRepository<>))
                    .ImplementedBy(typeof (PhotoOfCachesRepository<>))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (ICommentRepository<>))
                    .ImplementedBy(typeof (CommentRepository<>))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IListOfVisitedCachesRepository<>))
                    .ImplementedBy(typeof (ListOfVisitedCachesRepository<>))
                    .LifestyleTransient());
            ///////

            container.Register(
                Component.For(typeof (IValidator<User>)).ImplementedBy(typeof (UserValidator)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<PhotoOfUser>))
                    .ImplementedBy(typeof (PhotoOfUserValidator))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<Cache>)).ImplementedBy(typeof (CacheValidator)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<PhotoOfCaches>))
                    .ImplementedBy(typeof (PhotoOfCachesValidator))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<Comment>))
                    .ImplementedBy(typeof (CommentsValidator))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<ListOfVisitedCaches>))
                    .ImplementedBy(typeof (ListOfVisitedCachesValidator))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<Photo>)).ImplementedBy(typeof (PhotoValidator)).LifestyleTransient());
            /////



            container.Register(Component.For(typeof (IManager<>)).ImplementedBy(typeof (Manager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IUserManager<>)).ImplementedBy(typeof (UserManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IPhotoOfUserManager<>)).ImplementedBy(typeof (PhotoOfUserManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof (ICacheManager<>)).ImplementedBy(typeof (CacheManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IPhotoOfCachesManager<>))
                    .ImplementedBy(typeof (PhotoOfCachesManager<>))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (ICommentsManager<>))
                    .ImplementedBy(typeof (CommentsManager<>))
                    .LifestyleTransient());
            container.Register(
                Component.For(typeof (IListOfVisitedCachesManager<>))
                    .ImplementedBy(typeof (ListOfVisitedCachesManager<>))
                    .LifestyleTransient());
            //////

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
