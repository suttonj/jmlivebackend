using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

using JoinMeLive.DAL.Models;
using JoinMeLive.Helpers;

namespace JoinMeLive.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IUserHelper userHelper;

        public UserController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        /// <summary>
        /// Get details about an existing user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>User found in the system</returns>
        [HttpGet]
        public IHttpActionResult Get(long userId)
        {
            User user = this.userHelper.Get(userId);

            return this.Ok(user);
        }

        /// <summary>
        /// Insert a new user into the system.
        /// </summary>
        /// <param name="login">The user's join.me login</param>
        /// <param name="displayName">(optional) display name for the user on join.me live</param>
        /// <param name="photoUrl">(optional) url to a photo of the user</param>
        /// <param name="selfSummary">(optional) user self-summary to show on profile</param>
        /// <returns>Newly inserted user</returns>
        [HttpPost]
        public IHttpActionResult Insert(string login, string displayName, string photoUrl, string selfSummary)
        {
            User user = this.userHelper.Insert(displayName, photoUrl, selfSummary, login);

            return this.Ok(user);
        }
    }
}
