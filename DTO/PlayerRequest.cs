using System.ComponentModel.DataAnnotations;

namespace PG.API.DTO
{
    public class PlayerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(2)]
        public string NameIcon { get; set; }
    }
}
