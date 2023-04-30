using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tile;

namespace Client.Manager
{
    internal class ClientState
    {
        int row;
        int col;
        bool gameover;

        public ClientState()
        {
            gameover = false;
        }

        public void setGame(int num, int total)
        {
            if(num / 2 == 0) { row = 0; }
            else { row = 5; }
            if(num % 2 == 0) { col = 0; }
            else { col = 5; }
        }

        public void setLocation(int x, int y) { row = x; col = y; }
        public int ROW { get { return row; } }
        public int COL { get { return col; } }
        public int COL { get { return col; } }

        public void setGameOver() { gameover = true; }
        public bool isGameOver() {  return gameover; }
    }
}
