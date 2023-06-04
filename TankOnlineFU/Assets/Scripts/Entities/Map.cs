using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerations;

namespace Entities
{
    [Serializable]
    public class Map
    {
        public int Row;
        public int Column;
        public List<Position> Bricks;
        public List<Position> Waters;
        public List<Position> Stones;
        public List<Position> Bushes;
        public List<Position> Enemies;
        public List<Position> Players;
        public List<Position> Bases;
    }
}
