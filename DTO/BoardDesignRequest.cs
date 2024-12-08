using PG.API.DataModels;
using System;

namespace PG.API.DTO
{
    public class BoardDesignRequest 
    {
        public Guid Id { get; set; }
        public int BoardId { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
    }
}
