using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tile;
using WindowsFormsApp1.Connection_Control;

namespace Client.Manager
{
    internal class ClientState
    {
        string name;
        int row;
        int col;
        bool gameover;

        public ClientState(string name)
        {
            this.name = name;
            gameover = false;
        }

        public void setGame(int num)
        {
            if(num / 2 == 0) { row = 0; }
            else { row = 5; }
            if(num % 2 == 0) { col = 0; }
            else { col = 5; }
        }

        public void setLocation(int x, int y) { row = x; col = y; }
        public string Name { get { return name; } }
        public int ROW { get { return row; } }
        public int COL { get { return col; } }

        public void setGameOver() { gameover = true; }
        public bool isGameOver { get { return gameover; } }

        public void SendMessage(string message)
        {

        }
    }
}
