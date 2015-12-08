using System.Collections.Generic;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface IUserTagHelper
    {
        /// <summary>
        /// Get a list of the user's current favorite tags
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Tag> Get(long userId);

        /// <summary>
        /// Add a new favorite tag to the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagId"></param>
        /// <returns>A list of all the user's current favorite tags</returns>
        IEnumerable<Tag> Favorite(long userId, long tagId);

        /// <summary>
        /// Remove a favorite tag from the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagId"></param>
        /// <returns>A list of all the user's current favorite tags</returns>
        IEnumerable<Tag> Unfavorite(long userId, long tagId);
    }
}
