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

        private readonly ITagHelper tagHelper;

        public DiscussionHelper(LiveContext liveContext, ITagHelper tagHelper)
        {
            this.liveContext = liveContext;
            this.tagHelper = tagHelper;
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
            discussions = discussions.OrderByDescending(x => x.ParticipantCount).Skip(startResult ?? 0);
            if (maxResults.HasValue)
            {
                discussions = discussions.Take(maxResults.Value);
            }

            return discussions.ToList();
        }

        public Discussion Insert(string subject, long viewerCode, long categoryId, string previewImageUrl = null, IEnumerable<long> tagIds = null, int? participantCount = null)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("Subject must be specified");
            }

            var tags = this.tagHelper.GetTagsById(tagIds);

            return this.Insert(subject, viewerCode, categoryId, previewImageUrl, tags, participantCount);
        }

        public Discussion Insert(string subject, long viewerCode, long categoryId, string previewImageUrl = null, IEnumerable<Tag> tags = null, int? participantCount = null)
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
                ViewerCode = viewerCode,
                PreviewImageUrl = previewImageUrl,
                ParticipantCount = participantCount
            };

            // Get tags
            if (tags != null)
            {
                discussion.Tags = tags.ToList();
            }

            this.liveContext.Discussions.Add(discussion);
            this.liveContext.SaveChanges();

            return discussion;
        }

        public Discussion Update(Discussion discussion)
        {
            this.liveContext.SetAsModified(discussion);

            this.liveContext.SaveChanges();

            return discussion;
        }
    }
}
