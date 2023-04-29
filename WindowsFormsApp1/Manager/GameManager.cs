using System;
using System.Collections.Generic;
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
        List<ClientState> players;

        public int setBoom()
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
    }
}
