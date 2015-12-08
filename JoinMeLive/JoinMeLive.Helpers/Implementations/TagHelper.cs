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

        public Tag Get(long tagId)
        {
            var tag = this.liveContext.Tags.SingleOrDefault(x => x.Id == tagId);

            if (tag == null)
            {
                throw new ArgumentException("There is no tag with the id given");
            }

            return tag;
        }

        public IEnumerable<Tag> GetOrInsertTags(IEnumerable<string> tagNames)
        {
            List<Tag> finalTags = new List<Tag>();

            var existingTags = this.liveContext.Tags.Where(x => tagNames.Contains(x.Name));
            var existingNames = existingTags.Select(x => x.Name);

            finalTags.AddRange(existingTags);

            var tagsToAdd = tagNames.Where(x => !existingNames.Contains(x)).ToArray();

            if (!tagsToAdd.Any())
            {
                return finalTags;
            }

            // Add new tags
            foreach (var newTagName in tagsToAdd)
            {
                Tag newTag = new Tag { Name = newTagName };

                this.liveContext.Tags.Add(newTag);
                finalTags.Add(newTag);
            }

            this.liveContext.SaveChanges();

            return finalTags;
        }

        public IEnumerable<Tag> GetTagsById(IEnumerable<long> tagIds)
        {
            if (tagIds == null)
            {
                return new Tag[0];
            }

            return this.liveContext.Tags.Where(x => tagIds.Contains(x.Id));
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
    }
}
