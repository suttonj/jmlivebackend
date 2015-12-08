using System.Collections.Generic;

using JoinMeLive.DAL;
using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers.Implementations
{
    public class UserTagHelper : IUserTagHelper
    {
        private readonly LiveContext liveContext;

        private readonly ITagHelper tagHelper;

        private readonly IUserHelper userHelper;

        public UserTagHelper(LiveContext liveContext, ITagHelper tagHelper, IUserHelper userHelper)
        {
            this.liveContext = liveContext;
            this.tagHelper = tagHelper;
            this.userHelper = userHelper;
        }

        public IEnumerable<Tag> Get(long userId)
        {
            var user = this.userHelper.Get(userId);

            return user.Tags;
        }

        public IEnumerable<Tag> Favorite(long userId, long tagId)
        {
            var user = this.userHelper.Get(userId);
            var tag = this.tagHelper.Get(tagId);

            user.Tags.Add(tag);

            this.liveContext.SaveChanges();

            return user.Tags;
        }

        public IEnumerable<Tag> Unfavorite(long userId, long tagId)
        {
            var user = this.userHelper.Get(userId);
            var tag = this.tagHelper.Get(tagId);

            user.Tags.Remove(tag);

            this.liveContext.SaveChanges();

            return user.Tags;
        }
    }
}
