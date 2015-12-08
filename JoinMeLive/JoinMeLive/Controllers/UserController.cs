using System.Web.Http;
using System.Web.Http.Cors;

using JoinMeLive.DAL.Models;
using JoinMeLive.Helpers;
using JoinMeLive.Models;

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
        /// Inserts a new user into the system.
        /// </summary>
        /// <param name="insertUserModel">
        /// login (required) - the user's join.me login.
        /// displayName - (optional) display name for the user on join.me live
        /// photoUrl - (optional) url to a photo of the user
        /// selfSummary - (optional) user self-summary to show on profile
        /// </param>
        /// <returns>Newly inserted user</returns>
        [HttpPost]
        public IHttpActionResult Insert([FromBody] InsertUserModel insertUserModel)
        {
            User user = this.userHelper.Insert(insertUserModel.DisplayName, insertUserModel.PhotoUrl, insertUserModel.SelfSummary, insertUserModel.Login);

            return this.Ok(user);
        }

        /// <summary>
        /// Update something about a user
        /// </summary>
        /// /// <param name="updateUserModel">
        /// userId - The user id of the user to update
        /// displayName - (optional) new display name for the user
        /// photoUrl - (optional) new photo url for the user
        /// selfSummary - (optional) new self summary for the user
        /// </param>
        /// <returns>Newly inserted user</returns>
        [HttpPatch]
        public IHttpActionResult Update([FromBody] UpdateUserModel updateUserModel)
        {
            User user = this.userHelper.Update(updateUserModel.UserId, updateUserModel.DisplayName, updateUserModel.PhotoUrl, updateUserModel.SelfSummary);

            return this.Ok(user);
        }
    }
}
