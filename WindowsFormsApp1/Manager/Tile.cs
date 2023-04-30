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
        int row;
        int col;

        public Map() { 
            map = new bool[6, 6]{
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, false, false, false, false }
            };
            row = 6; col = 6;
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

        public bool[,] MAP
        {
            get { return map; }
        }

        public int ROW
        {
            get { return row; }
        }

        public int COL 
        {
            get { return col; }
        }

    }
}
