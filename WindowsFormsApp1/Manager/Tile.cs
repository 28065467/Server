using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tile
{
    internal class Map
    {
        bool[,] map;
        int ROW;
        int COL;

        public Map() { 
            map = new bool[6, 6]{
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false }
            };
            ROW = 6; COL = 6;
        }

        public int getROW()
        {
            return ROW;
        }

        public int getCOL() 
        { 
            return COL;
        }

    }
}
