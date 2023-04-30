using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Manager;
using Tile;
using WindowsFormsApp1;
using WindowsFormsApp1.Connection_Control;

namespace Game.Manager
{
    internal class GameManager
    {
        int round;
        Map map;
        List<ClientState> Players;
        Form1 form;
        Connection connection;

        public GameManager(Form1 form)
        {
            map = new Map();
            Players = new List<ClientState>();
            this.form = form;
            connection = new Connection(form);
        }

        public void addPlayers(ClientState player)
        {
            string message = "addPlayers;" ;
            int index = Players.Count;
            Players.Add(player);
            message += index.ToString() + ";;";
            connection.SentToSingleClient(index, message);   // "addPlayers;index;;" 通知此玩家編號
        }

        public bool GameStartSet()
        {
            string message = "GameStartSet;";
            if(Players.Count == 0 || Players.Count == 1)
            {
                connection.SentToAllClient(message + "-1;;"); // "GameStartSet;-1;;"   -1為玩家人數不足
                return false;
            }

            for(int i = 0; i < Players.Count; i++)
            {
                Players[i].setGame(i);
                connection.SentToAllClient(message + i.ToString() + ";" + Players[i].ROW.ToString() + " " + Players[i].COL.ToString() + ";");  // "GameStartSet;i;row col;"
            }
            round = 1;
            return true;
        }

        public void NewRound()
        {
            string message = "NewRound;";
            round++;
            connection.SentToAllClient(message + "-1;" + round.ToString() + ";");  // "NewRound;-1;round;" -1為回數通知
            for(int i = 0; i < Players.Count; i++)
            {
                if (Players[i].isGameOver)
                {
                    // 向所有玩家回傳此玩家已淘汰
                    connection.SentToAllClient(message + i.ToString() + ";" + "-1;"); // "NewRound;i;-1;"  -1為淘汰
                }
                else
                {
                    // 向所有玩家回傳此未淘汰玩家位置
                    connection.SentToAllClient(message + i.ToString() + ";" + Players[i].ROW.ToString() + " " + Players[i].COL.ToString() + ";");   // "NewRound;i;row col;"
                }
            }
        }

        public void setBoom(int x, int y) { map.setBoom(x, y); }

        public void EndRound()
        {
            string message = "EndRound;";
            for(int i = 0; i < Players.Count; i++)
            {
                int row = Players[i].ROW;
                int col = Players[i].COL;
                if (map.MAP[row, col] == true)
                {
                    Players[i].setGameOver();
                    connection.SentToAllClient(message + i.ToString() + ";;");  // "EndRound;i;;"
                }
            }
            map.clearBoom();
            CheckNewRound();
        }

        public void CheckNewRound()
        {
            int loser = 0;
            foreach (ClientState player in Players)
            {
                if (player.isGameOver) { loser++; }
            }

            if (loser == Players.Count - 1) { GameEnd(true); }
            else if(loser == Players.Count) { GameEnd(false); }
            else { NewRound(); }
        }

        public void GameEnd(bool win)
        {
            string message = "GameEnd;";
            if (win)
            {
                foreach (ClientState player in Players)
                {
                    if (!player.isGameOver) 
                    {
                        message += player.Name + ";;";
                        connection.SentToAllClient(message);   // "GameEnd;player.Name;;"
                        break; 
                    }
                }
            }
            else { connection.SentToAllClient(message + "no winner;;"); }  // "GameEnd;no winner;;"

        }

        #region Send
        /*
        public void SendAll(string message)
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
        }
        */
        #endregion
    }
}
