[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CinemaApp.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CinemaApp.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace CinemaApp.MVC.App_Start
{
    using System;
    using System.Web;
    using BLL;
    using IBL;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<IMovieDisplayService>().To<MovieDisplayService>();
                kernel.Bind<IReservationManageService>().To<ReservationManageService>();
                kernel.Bind<IReservationDisplayService>().To<ReservationDisplayService>();
                kernel.Bind<IUserAuthenticationService>().To<UserAuthenticationService>();
                kernel.Bind<IUserManageService>().To<UserManageService>();
                kernel.Bind<IScreeningDisplayService>().To<ScreeningDisplayService>();
                kernel.Bind<IScreeningManageService>().To<ScreeningManageService>();
                kernel.Bind<IRoomDisplayService>().To<RoomDisplayService>();
                kernel.Bind<IScreeningValidationService>().To<ScreeningValidationService>();
                kernel.Bind<IMovieManageService>().To<MovieManageService>();
                kernel.Bind<IGenreDisplayService>().To<GenreDisplayService>();
                kernel.Bind<IUploadImage>().To<UploadImage>();
                kernel.Bind<IReservationValidationService>().To<ReservationValidationService>();
                kernel.Bind<IUserDisplayService>().To<UserDisplayService>();
                kernel.Bind<IGenreManageService>().To<GenreManageService>();
                kernel.Bind<IGenreValidationService>().To<GenreValidationService>();
                kernel.Bind<IRoomValidationService>().To<RoomValidationService>();
                kernel.Bind<IRoomManageService>().To<RoomManageService>();
                kernel.Bind<IStripePayment>().To<StripePayment>();
                kernel.Bind<IStripePaymentValidation>().To<StripePaymentValidation>();



                




                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
