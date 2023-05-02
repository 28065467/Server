using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Tile;
using WindowsFormsApp1.Connection_Control;
using System.Windows.Forms;
namespace Client.Manager
{
    internal class ClientState
    {
        public int id;
        public int x;
        public int y;
        public bool gameover;
        public TcpClient tcpClient;
        bool[,] Bomb_Placed;
        public ClientState(TcpClient client, int ID)
        {
            id = ID;
            gameover = false;
            tcpClient = new TcpClient();
            tcpClient = client;
            Bomb_Placed = new bool[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Bomb_Placed[i, j] = false;
                }
            }
            Thread thread = new Thread(Client_Listening);
            thread.IsBackground = true;
            thread.Start();
        }
        private void Client_Listening()
        {
            NetworkStream networkStream = tcpClient.GetStream();

            while (true)
            {
                try
                {
                    if (networkStream.CanRead)
                    {
                        byte[] buffer = new byte[2048];
                        int BytesReaded = networkStream.Read(buffer, 0, buffer.Length);
                        if (BytesReaded <= 0)
                        {
                            //MessageBox.Show("Fail to Read");
                        }
                        else
                        {
                            string Message_From_Client = Encoding.UTF8.GetString(buffer, 0, BytesReaded);
                            string command = Message_From_Client.Substring(0,2);
                            if(command == "PB")//ex.PB32 => Place Bomb At (3,2)
                            {
                                int x = int.Parse(Message_From_Client.Substring(3,1));
                                int y = int.Parse(Message_From_Client.Substring(4,1));
                                Bomb_Placed[x,y] = true;
                            }
                            else if(command == "PL")//ex.PL33 => Player is At (3,3)
                            {
                                int X = int.Parse(Message_From_Client.Substring(3, 1));
                                int Y = int.Parse(Message_From_Client.Substring(4, 1));
                                x = X;
                                y = Y;
                            }
                            //MessageBox.Show("Sucessfully Receive " + Message_From_Client + " Form Client");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }
        public void setGame()
        {
            int tmp = id - 1;
            if(tmp / 2 == 0) { x = 0; }
            else { x = 5; }
            if(tmp % 2 == 0) { y = 0; }
            else { y = 5; }
        }

        public void setLocation(int X, int Y) { x = X; y = Y; }
        public int ROW { get { return x; } }
        public int COL { get { return y; } }

        public void setGameOver() { gameover = true; }
        public bool isGameOver { get { return gameover; } }

    }
}
