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

        public void setBoom(int x, int y)
        {
            map[x, y] = true;
        }

        public void clearBoom()
        {
            for(int i = 0; i < ROW; i++)
            {
                for(int j = 0; j < COL; j++)
                {
                    map[i, j] = false;
                }
            }
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
