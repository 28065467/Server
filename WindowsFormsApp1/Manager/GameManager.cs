using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Manager;
using Tile;
using WindowsFormsApp1.Connection_Control;
using System.Collections;
using WindowsFormsApp1;

namespace Game.Manager
{
    internal class GameManager
    {
        int round;
        Map map;
        //Dictionary<string,ClientState> Players;
        Form1 form;
        Connection connection;
        public GameManager(Form1 form, Connection connection)
        {
            this.form = form;
            this.connection = connection;
            map = new Map();
            //Players = new Dictionary<string, ClientState>();
            this.connection = connection;
        }

        /*public void addPlayers(ClientState player)
        {
            string message = "addPlayers;" ;
            int index = Players.Count;
            Players.Add((index+1).ToString(),player);
            message += index.ToString() + ";;";
            Send(message, index);   // "addPlayers;index;;" 通知此玩家編號
        }*/

        public bool GameStartSet()
        {
            string message = "GameStartSet;";
            if(connection.tcpClients.Count == 0 || connection.tcpClients.Count == 1)
            {
                connection.SentToAllClient(message + "-1;;"); // "GameStartSet;-1;;"   -1為玩家人數不足
                return false;
            }

            for(int i = 1 ; i < connection.tcpClients.Count; i++)
            {
                connection.tcpClients[i.ToString()].setGame(i);
                connection.SentToAllClient(message + i.ToString() + ";" + connection.tcpClients[i.ToString()].ROW.ToString() + " " + connection.tcpClients[i.ToString()].COL.ToString() + ";");  // "GameStartSet;i;row col;"
            }
            round = 1;
            return true;
        }

        public void NewRound()
        {
            string message = "NewRound;";
            round++;
            connection.SentToAllClient(message + "-1;" + round.ToString() + ";");  // "NewRound;-1;round;" -1為回數通知
            for(int i = 0; i < connection.tcpClients.Count; i++)
            {
                if (connection.tcpClients[i.ToString()].isGameOver)
                {
                    // 向所有玩家回傳此玩家已淘汰
                    connection.SentToAllClient(message + i.ToString() + ";" + "-1;"); // "NewRound;i;-1;"  -1為淘汰
                }
                else
                {
                    // 向所有玩家回傳此未淘汰玩家位置
                    connection.SentToAllClient(message + i.ToString() + ";" + connection.tcpClients[i.ToString()].ROW.ToString() + " " + connection.tcpClients[i.ToString()].COL.ToString() + ";");   // "NewRound;i;row col;"
                }
            }
        }

        public void setBoom(int x, int y) { map.setBoom(x, y); }

        public void EndRound()
        {
            string message = "EndRound;";
            for(int i = 0; i < connection.tcpClients.Count; i++)
            {
                int row = connection.tcpClients[i.ToString()].ROW;
                int col = connection.tcpClients[i.ToString()].COL;
                if (map.MAP[row, col] == true)
                {
                    connection.tcpClients[i.ToString()].setGameOver();
                    connection.SentToAllClient(message + i.ToString() + ";;");  // "EndRound;i;;"
                }
            }
            map.clearBoom();
            CheckNewRound();
        }

        public void CheckNewRound()
        {
            int loser = 0;
            foreach (var kvp in connection.tcpClients)
            {
                string client_ID = kvp.Key;
                ClientState clientState = kvp.Value;
                if (clientState.isGameOver) { loser++; }
            }

            if (loser == connection.tcpClients.Count - 1) { GameEnd(true); }
            else if(loser == connection.tcpClients.Count) { GameEnd(false); }
            else { NewRound(); }
        }

        public void GameEnd(bool win)
        {
            string message = "GameEnd;";
            if (win)
            {
                foreach (var kvp in connection.tcpClients)
                {
                    string client_ID = kvp.Key;
                    ClientState clientState = kvp.Value;
                    if (!(clientState.isGameOver)) 
                    {
                        message += (clientState.Name) + ";;";
                        connection.SentToAllClient(message);   // "GameEnd;player.Name;;"
                        break; 
                    }
                }
            }
            else { connection.SentToAllClient(message + "no winner;;"); }  // "GameEnd;no winner;;"

        }

        /*public void SendAll(string message)
        {
            foreach(ClientState player in Players)
            {
                player.SendMessage(message);
            }
        }

        public void Send(string message, int index)
        {
            Players[index].SendMessage(message);
        }

        public void SendOthers(string message, int index)
        {
            for(int i = 0; i < Players.Count; i++)
            {
                if(i == index) { continue; }
                else
                {
                    Players[i].SendMessage(message);
                }
            }
        }*/
    }
}
