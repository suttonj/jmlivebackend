using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface IUserHelper
    {
        User Get(long userId);

        User Insert(string displayName, string photoUrl, string selfSummary, string login);
    }
}
