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

        public void setBoom(int x, int y) { map.setBoom(x, y); }

        public void endRound()
        {
            for(int i = 0; i < players.Count; i++)
            {
                int row = players[i].ROW;
                int col = players[i].COL;
                if (map.MAP[row, col] == true) { players[i].setGameOver(); }
            }

            map.clearBoom();
        }
    }
}
