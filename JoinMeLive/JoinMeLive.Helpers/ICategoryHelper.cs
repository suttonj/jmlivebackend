using System;
using System.Collections.Generic;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface ICategoryHelper
    {
        /// <summary>
        /// Delete a category (mark deleted) in the system.
        /// If there are subcategories, they must be deleted first or use the includeSubcategories parameter for a recursive delete.
        /// Deleting a category does not delete active discussions currently in that category, but new discussions will not be able to start with the deleted category.
        /// </summary>
        /// <param name="categoryId">The category to delete</param>
        /// <param name="includeSubcategories">If subcategories should be deleted if found. If there are subcategories, and this is not true, an exception will be raised</param>
        void Delete(long categoryId, bool includeSubcategories = false);

        /// <summary>
        /// Insert a new category into the system.
        /// </summary>
        /// <param name="categoryName">Name for the desired category - should be unique under the parent category id</param>
        /// <param name="parentCategoryId">Parent category. Can be null for top level categories.</param>
        /// <returns></returns>
        Category Insert(string categoryName, long? parentCategoryId = null);

        /// <summary>
        /// Get a list of all categories directly under the specified category.
        /// If no parentCategory is specified, gets all top level categories.
        /// </summary>
        /// <param name="parentCategoryId">The parent category, if desired. (optional) default: null</param>
        /// <returns>List of categories</returns>
        IEnumerable<Category> List(long? parentCategoryId = null);
    }
}
