﻿using System.Collections.Generic;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.Helpers
{
    public interface IDiscussionHelper
    {
        /// <summary>
        /// Delete (end) a discussion
        /// </summary>
        /// <param name="discussionId"></param>
        void Delete(long discussionId);

        IEnumerable<Discussion> List(
            long? categoryId = null,
            IEnumerable<long> tagIds = null,
            int? maxResults = null,
            int? startResult = null,
            string q = null);

        Discussion Insert(string subject, long viewerCode, long categoryId, string previewImageUrl = null, IEnumerable<long> tagIds = null, int? participantCount = null);

        Discussion Insert(string subject, long viewerCode, long categoryId, string previewImageUrl = null, IEnumerable<Tag> tags = null, int? participantCount = null);

        Discussion Update(Discussion discussion);
    }
}
