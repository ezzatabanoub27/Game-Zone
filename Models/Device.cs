using System.ComponentModel.DataAnnotations;

namespace GameHUB.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Icon { get; set; } = string.Empty;

    }
}
