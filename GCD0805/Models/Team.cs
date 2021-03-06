using System.ComponentModel.DataAnnotations;

namespace GCD0805.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}