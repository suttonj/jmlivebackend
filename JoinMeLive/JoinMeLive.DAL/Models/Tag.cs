using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace JoinMeLive.DAL.Models
{
    public class Tag
    {
        [Index("IdAndNameIndex", 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        [Index("NameIndex")]
        [Index("IdAndNameIndex", 2, IsUnique = true)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Discussion> Topics { get; set; }
    }
}
