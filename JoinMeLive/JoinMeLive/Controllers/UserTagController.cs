using System.Web.Http;
using System.Web.Http.Cors;

using JoinMeLive.Helpers;
using JoinMeLive.Models;

namespace JoinMeLive.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserTagController : ApiController
    {
        private readonly IUserTagHelper userTagHelper;

        public UserTagController(IUserTagHelper userTagHelper)
        {
            this.userTagHelper = userTagHelper;
        }

        /// <summary>
        /// Get a list of all the user's favorited tags
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of all the user's current favorite tags</returns>
        [HttpGet]
        public IHttpActionResult Get(long userId)
        {
            var tags = this.userTagHelper.Get(userId);

            return this.Ok(tags);
        }

        /// <summary>
        /// Add a new tag to the user's list of favorites
        /// </summary>
        /// <param name="model">
        /// userId - User Id
        /// tagId -The tag Id to favorite
        /// </param>
        /// <returns>List of all the user's current favorite tags</returns>
        [HttpPost]
        public IHttpActionResult Favorite([FromBody] FavoriteUserTagModel model)
        {
            var tags = this.userTagHelper.Favorite(model.UserId, model.TagId);

            return this.Ok(tags);
        }

        /// <summary>
        /// Remove a tag from the user's list of favorites
        /// </summary>
        /// <param name="model">
        /// userId - User Id
        /// tagId -The tag Id to unfavorite
        /// </param>
        /// <returns>List of all the user's current favorite tags</returns>
        [HttpDelete]
        public IHttpActionResult Unfavorite([FromBody] FavoriteUserTagModel model)
        {
            var tags = this.userTagHelper.Unfavorite(model.UserId, model.TagId);

            return this.Ok(tags);
        }
    }
}
