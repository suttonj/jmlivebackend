using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinMeLive.Models
{
    public class InsertDiscussionModel
    {
        public string Subject { get; set; }

        public long ViewerCode { get; set; }

        public long? CategoryId { get; set; }

        public string PreviewImageUrl { get; set; }

        public string Tags { get; set; }

        public int? ParticipantCount { get; set; }
    }
}
