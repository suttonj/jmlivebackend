using System;
using System.Collections.Generic;
using System.Linq;

using JoinMeLive.DAL;
using JoinMeLive.DAL.Extensions;
using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers.Implementations
{
    public class DiscussionHelper : IDiscussionHelper
    {
        private readonly LiveContext liveContext;

        public DiscussionHelper(LiveContext liveContext)
        {
            this.liveContext = liveContext;
        }

        public void Delete(long discussionId)
        {
            DateTime deleteTime = DateTime.UtcNow;

            var discussion = this.liveContext.Discussions.SingleOrDefault(x => x.Id == discussionId && !x.End.HasValue);

            if (discussion == null)
            {
                throw new ArgumentException("There is no active discussion with the id given");
            }

            discussion.End = deleteTime;
            this.liveContext.SaveChanges();
        }

        public IEnumerable<Discussion> List(long? categoryId = null, IEnumerable<long> tagIds = null, int? maxResults = null, int? startResult = null, string q = null)
        {
            var discussions =
                this.liveContext.Discussions.FilterByActive()
                    .FilterByCategory(categoryId)
                    .FilterBySubject(q);

            if (tagIds != null)
            {
                discussions = tagIds.Aggregate(discussions, (current, tagId) => current.FilterByTag(tagId));
            }

            // TODO: Order by most popular?
            discussions = discussions.OrderBy(x => x.Id).Skip(startResult ?? 0);
            if (maxResults.HasValue)
            {
                discussions = discussions.Take(maxResults.Value);
            }

            return discussions.ToList();
        }

        public Discussion Insert(string subject, long viewerCode, long categoryId, IEnumerable<long> tagIds = null)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("Subject must be specified");
            }

            Discussion discussion = new Discussion
                                        {
                                            CategoryId = categoryId,
                                            Start = DateTime.UtcNow,
                                            Subject = subject,
                                            ViewerCode = viewerCode
                                        };

            // Get tags
            if (tagIds != null)
            {
                discussion.Tags = this.liveContext.Tags.Where(x => tagIds.Contains(x.Id)).ToList();
            }

            this.liveContext.Discussions.Add(discussion);
            this.liveContext.SaveChanges();

            return discussion;
        }
    }
}
