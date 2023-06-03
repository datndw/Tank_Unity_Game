using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerations;

namespace Entities
{
    public class Map
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public List<Cell> Cells { get; set; }
        public Dictionary<MapEntity, List<Position>> Data = new();
        
        public Map() { }

        public Map(int row, int column, List<Cell> cells, Dictionary<MapEntity, List<Position>> data)
        {
            Row = row;
            Column = column;
            Cells = cells;
            Data = data;
        }
    }
}
