using System.ComponentModel.DataAnnotations;

namespace GCD0805.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }

}