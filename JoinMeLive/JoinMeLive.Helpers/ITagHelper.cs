using System.Collections.Generic;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface ITagHelper
    {
        /// <summary>
        /// Get the single tag with the given id
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Tag Get(long tagId);

        /// <summary>
        /// Iterate through the given tag names, for each, if the tag does not exist it will be added.
        /// Returns a list of all tags, existing and newly inserted.
        /// </summary>
        /// <param name="tagNames"></param>
        /// <returns></returns>
        IEnumerable<Tag> GetOrInsertTags(IEnumerable<string> tagNames);

        /// <summary>
        /// Get all tags from the db with the given ids
        /// </summary>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        IEnumerable<Tag> GetTagsById(IEnumerable<long> tagIds);

        /// <summary>
        /// Insert a new tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        Tag Insert(string tagName);

        /// <summary>
        /// List the existing tags
        /// </summary>
        /// <param name="maxResults"></param>
        /// <param name="startResult"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        IEnumerable<Tag> List(int? maxResults = null, int? startResult = null, string q = null);
    }
}
