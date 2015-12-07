using System.Collections.Generic;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface ITagHelper
    {
        /// <summary>
        /// List the existing tags
        /// </summary>
        /// <param name="maxResults"></param>
        /// <param name="startResult"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        IEnumerable<Tag> List(int? maxResults = null, int? startResult = null, string q = null);

        /// <summary>
        /// Insert a new tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        Tag Insert(string tagName);
    }
}
