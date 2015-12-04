using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface IDiscussionHelper
    {
        /// <summary>
        /// Gets a list of currently active topics in the given category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<Discussion> List(Guid categoryId);
    }
}
