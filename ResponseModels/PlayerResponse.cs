using System;

namespace PG.API.ResponseModels
{
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameIcon { get; set; } // field to use in displaying into the board
    }
}
