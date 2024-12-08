using PG.API.DataModels;
using System;
using System.Collections.Generic;

namespace PG.API.ResponseModels
{
    public class BoardResponse 
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public string BoardMessage { get; set; }
        public virtual List<BoardDesignResponseModel> BoardDesigns { get; set; }
    }
    public class BoardDesignResponseModel
    {
        public Guid Id { get; set; }
        public int BoardId { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public string ColumnValue { get; set; }
    }

}
