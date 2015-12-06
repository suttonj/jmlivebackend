using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual Category ParentCategory { get; set; }
    }
}
