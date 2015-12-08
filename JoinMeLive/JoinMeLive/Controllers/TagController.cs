using System.Web.Http;
using System.Web.Http.Cors;

using JoinMeLive.DAL.Models;
using JoinMeLive.Helpers;
using JoinMeLive.Models;

namespace JoinMeLive.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TagController : ApiController
    {
        private readonly ITagHelper tagHelper;

        public TagController(ITagHelper tagHelper)
        {
            this.tagHelper = tagHelper;
        }

        /// <summary>
        /// Get a list of previously used tags
        /// </summary>
        /// <param name="maxResults">(optional) limit results to the given amount</param>
        /// <param name="startResult">(optional) for paging - skip results before returning list</param>
        /// <param name="q">(optional) query filter on tag name</param>
        /// <returns>List of tags</returns>
        [HttpGet]
        public IHttpActionResult List(int? maxResults = null, int? startResult = null, string q = null)
        {
            var tags = this.tagHelper.List(maxResults, startResult, q);

            return this.Ok(tags);
        }

        /// <summary>
        /// Create a new tag.
        /// </summary>
        /// <param name="model">tagName - Name for the desired tag.</param>
        /// <returns>The newly created tag</returns>
        [HttpPost]
        public IHttpActionResult Insert([FromBody] InsertTagModel model)
        {
            Tag tag = this.tagHelper.Insert(model.TagName);

            return this.Ok(tag);
        }
    }
}
