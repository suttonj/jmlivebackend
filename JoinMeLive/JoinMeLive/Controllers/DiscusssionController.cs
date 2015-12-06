using System.Collections.Generic;
using System.Web.Http;

using JoinMeLive.DAL.Models;
using JoinMeLive.Helpers;

namespace JoinMeLive.Controllers
{
    public class DiscusssionController : ApiController
    {
        private readonly IDiscussionHelper discussionHelper;

        public DiscusssionController(IDiscussionHelper discussionHelper)
        {
            this.discussionHelper = discussionHelper;
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
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult List(
            long? categoryId = null,
            string tagIds = null,
            int? maxResults = null,
            int? startResult = 0,
            string q = null)
        {
            var discussions = this.discussionHelper.List(categoryId, StringToLongList(tagIds), maxResults, startResult, q);

            return this.Ok(discussions);
        }

        /// <summary>
        /// Start a new discussion.
        /// </summary>
        /// <param name="subject">Subject for the new discussion</param>
        /// <param name="viewerCode">join.me viewer code used to join the discussion</param>
        /// <param name="categoryId">Lowest level category for the duscission</param>
        /// <param name="tagIds">(optional) comma seperated tag ids to use for the discussion</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Insert(
            string subject,
            long viewerCode,
            long categoryId,
            string tagIds = null)
        {
            Discussion discussion = this.discussionHelper.Insert(subject, viewerCode, categoryId, StringToLongList(tagIds));

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
