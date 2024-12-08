using System;

namespace PG.API.ResponseModels
{
    public class BoardPlayerResponse
    {
        public Guid Id { get; set; }
        public int BoardId { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
    }
}
