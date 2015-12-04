using System;
using System.Collections.Generic;
using System.Linq;

using JoinMeLive.DAL;
using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        private readonly LiveContext liveContext;

        public CategoryHelper(LiveContext liveContext)
        {
            this.liveContext = liveContext;
        }

        public IEnumerable<Category> List(Guid? parentCategoryId = null)
        {
            List<Category> categories = this.liveContext.Categories.Where(x => x.ParentCategoryId == parentCategoryId).ToList();
            return categories;
        }
        
        public Category Insert(string categoryName, Guid? parentCategoryId = null)
        {
            // Category name must be unique under parent.
            Category existingCategory = this.liveContext.Categories.FirstOrDefault(x => x.ParentCategoryId == parentCategoryId && x.Name == categoryName);
            if (existingCategory != null)
            {
                throw new ArgumentException($"Category name must be unique under the given parent category. A category {existingCategory.Name} already exists");
            }

            Category newCategory = new Category() { Name = categoryName, ParentCategoryId = parentCategoryId };

            this.liveContext.Categories.Add(newCategory);
            this.liveContext.SaveChanges();

            return newCategory;
        }
    }
}
