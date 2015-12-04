using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinMeLive.DAL.Models
{
    public class Tag
    {
        [Index("IdAndNameIndex", 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index("NameIndex")]
        [Index("IdAndNameIndex", 2, IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Discussion> Topics { get; set; }
    }
}
