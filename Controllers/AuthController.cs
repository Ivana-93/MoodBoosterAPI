using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using FirebaseAdmin.Auth;
using MoodAPI.Bases;
using MoodAPI.Models;
using MoodAPI.Models.Auth;
using MoodAPI.Services;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace MoodAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {

        private readonly FirebaseAuthClient client;
        public AuthController()
        {
            client = CreateFirebaseAuthClient();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<BaseResponse> LoginAsync(LoginCredentials credentials)
        {
            try
            {
                if (!AreCredentailsValid(credentials))
                {
                    throw new Exception("Invalid credentials");
                }

                if (!IsEmailValid(credentials.Email))
                {
                    throw new Exception($"Invalid email: {credentials.Email}");
                }

                if (!IsPasswordValid(credentials.Password))
                {
                    throw new Exception("Password needs to have minimum 8 char.");
                }

                var user = FirebaseService.Instance.GetUser(GetFireBaseEmail(credentials.Email));

                var hashedCredentialPassword = Helper.Hash(credentials.Password);

                if (user == null)
                {
                    throw new Exception("User not exist");
                }

                if (user.Password != hashedCredentialPassword)
                {
                    throw new Exception("Invalid password");
                }

                var credential = await client.SignInWithEmailAndPasswordAsync(user.Email, user.Password);
                var idToken = await credential.User.GetIdTokenAsync();
                user.Password = string.Empty;

                return CreateOkResponse(new { token = idToken, user });
            }
            catch (Exception)
            {
                return CreateErrorResponse("Auth fail");
            }
        }




        [HttpPost]
        [Route("api/auth/registration")]
        public async Task<BaseResponse> RegistrationAsync(RegistrationData regData)
        {

            try
            {
                if (!IsRegDataValid(regData))
                {
                    throw new Exception("Reg data is invalid");
                }

                if (!IsEmailValid(regData.Email))
                {
                    throw new Exception("Email invalid");
                }

                if (!IsPasswordValid(regData.Password))
                {
                    throw new Exception("Password needs to have minimum 8 char.");
                }

                if (DoesEmailExist(GetFireBaseEmail(regData.Email)))
                {
                    throw new Exception("Email exists");
                }

                var user = new Models.Auth.User
                {
                    Email = regData.Email,
                    Password = Helper.Hash(regData.Password),
                    Id = Guid.NewGuid().ToString(),
                    FirstName = regData.FirstName,
                    LastName = regData.LastName
                };

                FirebaseService.Instance.CreateAndUpdateUser(user);
                FirebaseService.Instance.UpdateUsers(user.Id, GetFireBaseEmail(user.Email));

                await client.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);

                return CreateOkResponse();
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e.Message);
            }
        }

        private bool IsRegDataValid(RegistrationData regData)
        {
            return regData != null &&
                !string.IsNullOrEmpty(regData.Email) &&
                !string.IsNullOrEmpty(regData.Password) &&
                !string.IsNullOrEmpty(regData.LastName) &&
                !string.IsNullOrEmpty(regData.FirstName);
        }

        private bool AreCredentailsValid(LoginCredentials credentials)
        {
            return credentials != null &&
                !string.IsNullOrEmpty(credentials.Email) &&
                !string.IsNullOrEmpty(credentials.Password);
        }


        private bool IsEmailValid(string email)
        {
            bool valid = true;
            if (!Regex.IsMatch(email, "^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})$"))
            {
                valid = false;
            }
            return valid;
        }


        private bool DoesEmailExist(string email)
        {
            Users users = FirebaseService.Instance.GetUsers();

            if (users == null)
            {
                FirebaseService.Instance.CreateUsers();
                users = new Users();
            }

            return users.UserData.ContainsKey(email);
        }


        private bool IsPasswordValid(string password)
        {
            bool valid = true;
            if (password.Length < 8)
            {
                valid = false;
            }

            return valid;
        }



        private FirebaseAuthClient CreateFirebaseAuthClient()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = Helper.FirebaseApiKey,
                AuthDomain = "ng-mood-booster.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
            };
            return new FirebaseAuthClient(config);
        }


    }
}
