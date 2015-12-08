using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

using JoinMeLive.DAL.Models;
using JoinMeLive.Helpers;
using JoinMeLive.Models;

namespace JoinMeLive.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DiscussionController : ApiController
    {
        private readonly IDiscussionHelper discussionHelper;

        private readonly ITagHelper tagHelper;

        public DiscussionController(IDiscussionHelper discussionHelper, ITagHelper tagHelper)
        {
            this.discussionHelper = discussionHelper;
            this.tagHelper = tagHelper;
        }

        /// <summary>
        /// Delete (end) a discussion.
        /// This should be called when the discussion is over.
        /// </summary>
        /// <param name="discussionId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(long discussionId)
        {
            this.discussionHelper.Delete(discussionId);

            return this.Ok();
        }

        /// <summary>
        /// Get a list of active discussions.
        /// </summary>
        /// <param name="categoryId">(optional) only include discussions in this category</param>
        /// <param name="tagIds">(optional) only include discussions with all of the given tags - comma seperated list of tagIds</param>
        /// <param name="maxResults">(optional) limit results to the given amount</param>
        /// <param name="startResult">(optional) for paging - skip results before returning list</param>
        /// <param name="q">(optional) query filter on discussion name</param>
        /// <returns>List of discussions</returns>
        [HttpGet]
        public IHttpActionResult List(
            long? categoryId = null,
            string tagIds = null,
            int? maxResults = null,
            int? startResult = 0,
            string q = null)
        {
            var discussions = this.discussionHelper.List(categoryId, this.StringToLongList(tagIds), maxResults, startResult, q);

            return this.Ok(discussions);
        }

        /// <summary>
        /// Start a new discussion.
        /// </summary>
        /// <param name="model">
        /// subject - Subject for the new discussion
        /// viewerCode - join.me viewer code used to join the discussion
        /// categoryId -Lowest level category for the duscission
        /// previewImageUrl - The image which will be used as the preview image in the UI
        /// tags - (optional) comma seperated tags (as string) to use for the discussion
        /// participantCount - the count of participants - this is for inserting test data
        /// </param>
        /// <returns>The newly created discussion</returns>
        [HttpPost]
        public IHttpActionResult Insert([FromBody] InsertDiscussionModel model)
        {
            IEnumerable<Tag> tagObjects = string.IsNullOrWhiteSpace(model.Tags) ? new Tag[0] : this.tagHelper.GetOrInsertTags(model.Tags.Split(','));

            Discussion discussion = this.discussionHelper.Insert(model.Subject, model.ViewerCode, model.CategoryId, model.PreviewImageUrl, tagObjects, model.ParticipantCount);

            return this.Ok(discussion);
        }

        private List<long> StringToLongList(string s)
        {
            List<long> myList = new List<long>();

            if (!string.IsNullOrEmpty(s))
            {
                var values = s.Split(',');
                foreach (var value in values)
                {
                    long longValue;
                    if (long.TryParse(value, out longValue))
                    {
                        myList.Add(longValue);
                    }
                }
            }

            return myList;
        }
    }
}
