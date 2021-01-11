using HotelManagementDBA.Interface;
using HotelManagementDBA.Repository;
using HotelManagementDBA.Repository.Interface;
using HotelManagementInterface;
using HotelManagementInterface.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApiAssigmnment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IHotel,HotelManager>();
            container.RegisterType<IRoom, RoomManager>();
            container.RegisterType<IBooking, BookingManager>();
            container.RegisterType<IHotelRepository, HotelRepository>();
            container.RegisterType<IRoomRepository, RoomRepository>();
            container.RegisterType<IBookingRepository, BookingRepository>();
            container.RegisterType<ILogin, LoginManager>();
            container.RegisterType<ILoginRepository, LoginRepository>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}