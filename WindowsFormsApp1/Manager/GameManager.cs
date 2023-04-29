using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Manager;
using Tile;

namespace Game.Manager
{
    internal class GameManager
    {
        int boom;
        Map map;
        List<ClientState> players;

        public GameManager()
        {
            map = new Map();
            players = new List<ClientState>();
        }

        public void addPlayers(ClientState player)
        {
            players.Add(player);
        }

        public int setBoomNum()
        {
            if(players.Count == 4)
            {
                boom = 3;
            }
            else if(players.Count == 3) 
            {
                boom = 4;
            }
            else if(players.Count == 2)
            {
                boom = 5;
            }

            return boom;
        }

        public void setBoom(int x, int y) { map.setBoom(x, y); }

        public void endRound()
        {
            for(int i = 0; i < players.Count; i++)
            {
                int row = players[i].getRow();
                int col = players[i].getCol();
                if (map.getMap()[row, col] == true) { players[i].setGameOver(); }
            }

            map.clearBoom();
        }
    }
}
