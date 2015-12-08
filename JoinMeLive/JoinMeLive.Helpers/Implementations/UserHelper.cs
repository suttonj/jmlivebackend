using System;
using System.Linq;

using JoinMeLive.DAL;
using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers.Implementations
{
    public class UserHelper : IUserHelper
    {
        private readonly LiveContext liveContext;

        public UserHelper(LiveContext liveContext)
        {
            this.liveContext = liveContext;
        }

        public User Get(long userId)
        {
            var user = this.liveContext.Users.SingleOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("There is no user with the id given");
            }

            return user;
        }

        public User Insert(string displayName, string photoUrl, string selfSummary, string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Login must be specifed");
            }

            User user = new User { DisplayName = displayName, PhotoUrl = photoUrl, SelfSummary = selfSummary, Login = login };

            this.liveContext.Users.Add(user);
            this.liveContext.SaveChanges();

            return user;
        }

        public User Update(long userId, string displayName, string photoUrl, string selfSummary)
        {
            User user = this.liveContext.Users.SingleOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("There is no user with the id given");
            }

            if (!string.IsNullOrWhiteSpace(displayName))
            {
                user.DisplayName = displayName;
            }

            if (!string.IsNullOrWhiteSpace(photoUrl))
            {
                user.PhotoUrl = photoUrl;
            }

            if (!string.IsNullOrWhiteSpace(selfSummary))
            {
                user.SelfSummary = selfSummary;
            }

            this.liveContext.SaveChanges();
            return user;
        }
    }
}
