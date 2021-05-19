using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Autofac;

using Autofac.Integration.WebApi;
using System.Reflection;
using WebExperience.Test.Module;
using Autofac.Integration.Mvc;

namespace WebExperience.Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            var config = GlobalConfiguration.Configuration;


           // Autofac Configuration
            var builder = new Autofac.ContainerBuilder();
           
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

           
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());

           // Register your Web API controllers.
           
           builder.RegisterApiControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            //OPTIONAL: Register the Autofac filter provider.
           builder.RegisterWebApiFilterProvider(config);

            //OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            //Set the dependency resolver to be Autofac.


           var container = builder.Build();

            //  DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);



            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.EnsureInitialized();

            

        }
    }
}
