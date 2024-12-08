using System.ComponentModel.DataAnnotations;

namespace PG.API.DTO
{
    public class PlayGameRequest
    {
        [Required]
        public int BoardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Row{ get; set; }
        [Required]
        public int Column { get; set; }
    }
}
