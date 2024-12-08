using System;

namespace PG.API.DataModels
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string NameIcon { get; set; } // field to use in displaying into the board
    }
}
