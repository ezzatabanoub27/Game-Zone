using System.ComponentModel.DataAnnotations;

namespace GameHUB.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(500)]
        public string Cover { get; set; }
        public int cateogryId { get; set; }

        public Cateogry cateogry { get; set; } = default;

        public ICollection<GameDevice> gameDevices { get; set; }=new List<GameDevice>();

    }
}
