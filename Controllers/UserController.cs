using MoodAPI.Models.Auth;
using MoodAPI.Services;
using System.Web.Http;

namespace MoodAPI.Controllers
{
    public class UserController : ApiController
    {




        // GET: api/User
        public User Get()
        {
            return FirebaseService.Instance.GetUser("someemail*com");
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
