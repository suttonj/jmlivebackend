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
        /// Get a list of existing categories
        /// </summary>
        /// <param name="parentCategoryId">(optional) parent category id</param>
        /// <returns></returns>
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
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Insert(string categoryName, long? parentCategoryId = null)
        {
            Category category = this.categoryHelper.Insert(categoryName, parentCategoryId);

            return this.Ok(category);
        }
    }
}
