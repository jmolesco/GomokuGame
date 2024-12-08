using System;

namespace PG.API.DataModels
{
    public class BoardDesign
    {
        public Guid Id { get; set; }
        public int BoardId { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public string ColumnValue { get; set; }
        public BoardGame BoardGames { get; set; }

    }
}
