﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace JoinMeLive.DAL.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string DisplayName { get; set; }
        
        public string PhotoUrl { get; set; }

        public string SelfSummary { get; set; }

        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// join.me Login
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Favorited Tags
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
