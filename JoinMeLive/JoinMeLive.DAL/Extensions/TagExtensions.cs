using System.Linq;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL.Extensions
{
    public static class TagExtensions
    {
        public static IQueryable<Tag> FilterByName(this IQueryable<Tag> tags, string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return tags;
            }

            return tags.Where(x => x.Name.Contains(q));
        }
    }
}
