using ProductAccessLayer;
using ProductAccessLayer.Interface;
using ProductDatabase.Repository;
using ProductDBA.Repository;
using ProductInterface;
using ProductInterface.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProductApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ILoginManager, LoginManager>();
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IProductManager, ProductManager>();
            container.RegisterType<IProdcutRepository, ProductRepository>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}