using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL.Extensions
{
    public static class DiscussionExtensions
    {
        /// <summary>
        /// Returns just the active discussions
        /// </summary>
        /// <param name="discussions"></param>
        /// <returns></returns>
        public static IQueryable<Discussion> FilterByActive(this IQueryable<Discussion> discussions)
        {
            return discussions.Where(x => !x.End.HasValue);
        }

        /// <summary>
        /// Returns just discussions in the given category (not including subcategories)
        /// </summary>
        /// <param name="discussions"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static IQueryable<Discussion> FilterByCategory(this IQueryable<Discussion> discussions, long? categoryId)
        {
            if (!categoryId.HasValue)
            {
                return discussions;
            }

            return discussions.Where(x => x.CategoryId == categoryId.Value);
        }

        /// <summary>
        /// This is NOT production ready code.
        /// Highly inefficient search.
        /// </summary>
        public static IQueryable<Discussion> FilterBySubject(this IQueryable<Discussion> discussions, string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return discussions;
            }

            return discussions.Where(x => x.Subject.Contains(q));
        }

        /// <summary>
        /// Returns just discussions that have the given tag
        /// </summary>
        /// <param name="discussions"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public static IQueryable<Discussion> FilterByTag(this IQueryable<Discussion> discussions, long? tagId)
        {
            if (!tagId.HasValue)
            {
                return discussions;
            }

            return discussions.Where(x => x.Tags.Any(t => t.Id == tagId.Value));
        }
    }
}
