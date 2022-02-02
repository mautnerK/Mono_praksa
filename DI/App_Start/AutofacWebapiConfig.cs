using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Projekt.Model;
using projekt.service;
using projekt.repository;

namespace AutoFacWithWebAPI.App_Start
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder())); 
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        


        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


           

            builder.RegisterModule(new ServiceDIModule());
            builder.RegisterModule(new RepositoryDIModule());


            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}