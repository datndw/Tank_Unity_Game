using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Map
    {
        public int[] Size = new int[] { 64, 64 };

        public int[][] Location = new int[][] {};
        
        public Map() { }

        public Map(int[] size, int[][] location)
        {
            Size = size;
            Location = location;
        }
    }
}
