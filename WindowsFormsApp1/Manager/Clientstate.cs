using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tile;

namespace ClientState
{
    internal class Clientstate
    {
        string name;
        int row;
        int col;
        int booms; // 在client計算就好 之後刪掉
        bool gameover;

        public Clientstate(string str)
        {
            name = str;
            gameover = false;
        }

        public void setGame(int num, int total)
        {
            if(num / 2 == 0) { row = 0; }
            else { row = 5; }
            if(num % 2 == 0) { col = 0; }
            else { col = 5; }

 //           if(total == 4) { booms = 3; }
 //           else if(total == 3) {  booms = 4; }
 //           else if(total == 2) { booms = 5; }
        }

        public string getName() { return name; }
        public void setLocation(int x, int y) { row = x; col = y; }
        public int getRow() { return row; }
        public int getCol() { return col; }

        public void setGameOver() { gameover = true; }
        public bool isGameOver() {  return gameover; }
    }
}
