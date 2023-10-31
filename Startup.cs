using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(MoodAPI.Startup))]

namespace MoodAPI
{
    public partial class Startup
    {
        public OAuthAuthorizationServerOptions OAuthAuthorizationServerOptions { get; set; }
        public void Configuration(IAppBuilder app)
        {
            //You don't need these lines if you are using bearer token as the token is 
            //passed in the request header and not in the cookie
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            OAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/auth"),
                Provider = new OAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                AllowInsecureHttp = true
            };

            //Remove this part
            //app.UseOAuthBearerTokens(OAuthOptions);

            //And try to manually define the authorization server 
            //and the middleware to handle the tokens
            app.UseOAuthAuthorizationServer(OAuthAuthorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
