using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoinMeLive.DAL;
using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers.Implementations
{
    public class DiscussionHelper
    {
        private readonly LiveContext liveContext;

        public DiscussionHelper(LiveContext liveContext)
        {
            this.liveContext = liveContext;
        }

        public IEnumerable<Discussion> List(long categoryId)
        {
            List<Discussion> topics = this.liveContext.Topics.Where(x => x.CategoryId == categoryId).ToList();
            return topics;
        }
    }
}
