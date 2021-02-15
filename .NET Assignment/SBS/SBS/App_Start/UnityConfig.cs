using SBS.BAL.Helper;
using SBS.BAL.Interface;
using SBS.BAL.Manager;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SBS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IAuthenticationManager, AuthenticationManager>();
            container.RegisterType<IDealerManager, DealerManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IBookingManager, BookingManager>();
            container.RegisterType<IMechanicManager, MechanicManager>();
            container.RegisterType<ICustomerManager, CustomerManager>(); ;
            container.AddNewExtension<UnityRepositoryHelper>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}