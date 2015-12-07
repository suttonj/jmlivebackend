using System.Collections.Generic;
using System.Web.Http;

using JoinMeLive.DAL.Models;
using JoinMeLive.Helpers;

namespace JoinMeLive.Controllers
{
    /// <summary>
    /// Categories
    /// </summary>
    public class CategoryController : ApiController
    {
        private readonly ICategoryHelper categoryHelper;

        public CategoryController(ICategoryHelper categoryHelper)
        {
            this.categoryHelper = categoryHelper;
        }

        /// <summary>
        /// Delete a category.
        /// Will prevent the category from coming up in List.
        /// Does not delete active discussions in the category, but will prevent new discussions in the category from starting.
        /// </summary>
        /// <param name="categoryId">Category to delete</param>
        /// <param name="includeSubcategories">If subcategories should be deleted. If there are subcategories, this must be true or delete will fail.</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(long categoryId, bool includeSubcategories = false)
        {
            this.categoryHelper.Delete(categoryId, includeSubcategories);

            return this.Ok();
        }

        /// <summary>
        /// Get a list of existing categories
        /// </summary>
        /// <param name="parentCategoryId">(optional) parent category id</param>
        /// <returns>List of categories</returns>
        [HttpGet]
        public IHttpActionResult List(long? parentCategoryId = null)
        {
            IEnumerable<Category> categories = this.categoryHelper.List(parentCategoryId);

            return this.Ok(categories);
        }

        /// <summary>
        /// Insert a new category
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <param name="parentCategoryId">(optional) parent category id</param>
        /// <returns>The newly created category</returns>
        [HttpPost]
        public IHttpActionResult Insert(string categoryName, long? parentCategoryId = null)
        {
            Category category = this.categoryHelper.Insert(categoryName, parentCategoryId);

            return this.Ok(category);
        }
    }
}
