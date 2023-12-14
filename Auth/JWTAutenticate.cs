using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http.Filters;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using System.Security.Claims;
using MoodAPI.Models;

namespace MoodAPI.Auth
{
    public class JWTAuthenticate : Attribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
                return;

            if (authorization.Scheme != "Bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing token", request);
                return;
            }

            FirebaseToken firebaseToken;
            try
            {
                FirebaseApp firebaseApp = FirebaseApp.GetInstance(Helper.FirebaseApiKey);

                if (firebaseApp == null)
                {
                    firebaseApp = FirebaseApp.Create(Helper.FirebaseApiKey);
                }

                firebaseToken = await FirebaseAuth.GetAuth(firebaseApp).VerifyIdTokenAsync(authorization.Parameter);

            }
            catch (Exception ex)
            {

                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                return;
            }


            IPrincipal principal = new GenericPrincipal(new ClaimsIdentity(ToClaims(firebaseToken.Claims)), new string[] { "user" });

            if (principal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                return;
            }
            else
            {
                context.Principal = principal;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }


        public bool AllowMultiple
        {
            get { return false; }
        }

        private IEnumerable<Claim> ToClaims(IReadOnlyDictionary<string, object> claims)
        {
            return new List<Claim>
            {
                new Claim("email", claims["email"].ToString()),
            };
        }

    }
}