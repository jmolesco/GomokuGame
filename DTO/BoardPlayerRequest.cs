using System;
using System.ComponentModel.DataAnnotations;

namespace PG.API.DTO
{
    public class BoardPlayerRequest
    {
        [Required]
        public int BoardId { get; set; }
        [Required]
        public string Player1 { get; set; }
        [Required]
        public string Player2 { get; set; }
    }
}
