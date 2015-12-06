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

        public void Delete(long categoryId, bool includeSubcategories = false)
        {
            DateTime deleteTime = DateTime.UtcNow;

            // Query for subcategories
            var subCategories =
                this.liveContext.Categories.Where(x => x.ParentCategoryId == categoryId && (!x.ActiveUntil.HasValue || x.ActiveUntil.Value > DateTime.UtcNow));
            if (subCategories.Any())
            {
                if (!includeSubcategories)
                {
                    throw new InvalidOperationException("Can not delete category because it has subcategories. You must delete subcategories first, or use parameter includeSubcategories = true");
                }

                // Inactivate subcategories
                foreach (var subCategory in subCategories)
                {
                    subCategory.ActiveUntil = deleteTime;
                }
            }

            // Query for main category
            var category =
                this.liveContext.Categories.SingleOrDefault(x => x.Id == categoryId && (!x.ActiveUntil.HasValue || x.ActiveUntil.Value > DateTime.UtcNow));

            if (category == null)
            {
                throw new ArgumentException("There is no active category with the id given");
            }

            category.ActiveUntil = deleteTime;
            this.liveContext.SaveChanges();
        }

        public IEnumerable<Category> List(long? parentCategoryId = null)
        {
            var categories = this.liveContext.Categories.Where(x => x.ParentCategoryId == parentCategoryId && (!x.ActiveUntil.HasValue || x.ActiveUntil.Value > DateTime.UtcNow)).ToList();
            return categories;
        }
        
        public Category Insert(string categoryName, long? parentCategoryId = null)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Category name must be specified");
            }

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
