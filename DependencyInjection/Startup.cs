using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DependencyInjection.Startup))]

namespace DependencyInjection
{
    using System.Web.Http;

    using DependencyInjection.QueryHandlers;
    using DependencyInjection.Services;

    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new Container();
            container.RegisterWebApiRequest<ITransientService, TransientService>();
            container.RegisterWebApiRequest<ITransientQueryHandler, TransientQueryHandler>();

            container.Verify();

            var config = ConfigureWebApi();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            app.UseWebApi(config);
        }

        private static HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }
    }
}