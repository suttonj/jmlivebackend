using System;
using System.Collections.Generic;
using System.Linq;

using JoinMeLive.DAL;
using JoinMeLive.DAL.Extensions;
using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers.Implementations
{
    public class TagHelper : ITagHelper
    {
        private readonly LiveContext liveContext;

        public TagHelper(LiveContext liveContext)
        {
            this.liveContext = liveContext;
        }

        public IEnumerable<Tag> List(int? maxResults = null, int? startResult = null, string q = null)
        {
            var tags = this.liveContext.Tags.FilterByName(q);

            // TODO: Order by ?
            tags = tags.OrderBy(x => x.Id).Skip(startResult ?? 0);
            if (maxResults.HasValue)
            {
                tags = tags.Take(maxResults.Value);
            }

            return tags.ToList();
        }

        public Tag Insert(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentException("Tag name must be specified");
            }

            // Tag must be unique
            Tag existingTag = this.liveContext.Tags.FirstOrDefault(x => x.Name == tagName);
            if (existingTag != null)
            {
                throw new ArgumentException($"Tag name must be unique. A tag {existingTag.Name} already exists");
            }

            Tag newTag = new Tag
                             {
                                 Name = tagName
                             };

            this.liveContext.Tags.Add(newTag);
            this.liveContext.SaveChanges();

            return newTag;
        }
    }
}
