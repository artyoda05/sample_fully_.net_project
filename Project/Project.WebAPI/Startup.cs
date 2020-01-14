using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Project.WebAPI.Providers;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Project.WebAPI.Ninject;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(Project.WebAPI.Startup))]

namespace Project.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        private static StandardKernel CreateKernel()
        {
            return new StandardKernel(new Project.WebAPI.Ninject.NinjectBinding());
        }
    }
}