using System;

namespace PG.API.DataModels
{
    public class BoardPlayer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int BoardId { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public BoardGame BoardGame { get; set; }
       
    }
}
