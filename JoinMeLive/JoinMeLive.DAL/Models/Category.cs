using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace JoinMeLive.DAL.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [ForeignKey("ParentCategory")]
        public long? ParentCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime? ActiveUntil { get; set; }

        [JsonIgnore]
        public virtual Category ParentCategory { get; set; }
    }
}
