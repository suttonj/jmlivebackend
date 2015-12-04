using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinMeLive.DAL.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ParentCategory")]
        public Guid? ParentCategoryId { get; set; }

        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
    }
}
