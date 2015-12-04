using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        /// Insert a new category
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <param name="parentCategoryId">(optional) parent category id</param>
        /// <returns></returns>
        public IHttpActionResult Insert(string categoryName, Guid? parentCategoryId = null)
        {
            Category category = this.categoryHelper.Insert(categoryName, parentCategoryId);

            return this.Ok(category);
        }
    }
}
