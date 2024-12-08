using System.Collections.Generic;

namespace PG.API.DataModels
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public virtual ICollection<BoardDesign> BoardDesigns { get; set; }
    }
}
