﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JoinMeLive.DAL.Extensions;

using Newtonsoft.Json;

namespace JoinMeLive.DAL.Models
{
    /// <summary>
    /// Represents a discussion
    /// </summary>
    public class Discussion : IIdsEqual<Discussion>
    {
        private static Random random = new Random();

        /// <summary>
        /// Uniquely identifies this Topic
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// User specified subject for this discussion
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// join.me Viewer Code (Populated when the discussion is started)
        /// </summary>
        [Required]
        public long ViewerCode { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        /// <summary>
        /// Lowest level category
        /// </summary>
        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        public int? ParticipantCount { get; set; }

        public string PreviewImageUrl { get; set; } = $"http://lorempixel.com/200/200/?{random.RandomString(10)}";

        [JsonIgnore]
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

        public bool IdsEqual(Discussion other)
        {
            return other.Id == this.Id;
        }
    }
}
