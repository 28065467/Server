using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tile;
using WindowsFormsApp1.Connection_Control;

namespace Client.Manager
{
    internal class ClientState
    {
        public string name;
        public int row;
        public int col;
        public bool gameover;
        public TcpClient tcpClient;
        public ClientState(TcpClient client)
        {
            //this.name = name;
            gameover = false;
            tcpClient = new TcpClient();
            tcpClient = client;
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
