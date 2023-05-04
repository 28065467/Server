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
        public Connection connection;
        bool Stop = false;
        bool ALL_DEAD = false;
        public GameManager(Form1 form, Connection connection)
        {
            this.form = form;
            this.connection = connection;
            map = new Map();
            //Players = new Dictionary<string, ClientState>();
        }

        #region Add Players
        /*public void addPlayers(ClientState player)
        {
            string message = "addPlayers;" ;
            int index = Players.Count;
            Players.Add((index+1).ToString(),player);
            message += index.ToString() + ";;";
            Send(message, index);   // "addPlayers;index;;" 通知此玩家編號
        }*/
        #endregion

        public bool GameStartSet()  // GS
        {
            if(connection.tcpClients.Count == 0 || connection.tcpClients.Count == 1)
            {
                //o0l9o0connection.SentToAllClient(message + "-;;"); // "GS;-;;"   玩家人數不足
                return false;
            }

                connection.SentToAllClient("GS");
            for(int i = 1 ; i <= connection.tcpClients.Count; i++)
            {
                connection.tcpClients[i.ToString()].setGame();
                connection.SentToAllClient("PL" + i.ToString() + connection.tcpClients[i.ToString()].ROW.ToString()+ connection.tcpClients[i.ToString()].COL.ToString());  // "PLiXY;" 玩家i所在座標
            }
            round = 1;
            return true;
        }
        public void Gameloop(object source , System.Timers.ElapsedEventArgs e)
        {
            NewRound();
            EndRound();
            CheckNewRound();
            if (Stop)
            {
                if(ALL_DEAD)
                    GameEnd(false);
                else
                    GameEnd(true);
                form.timer.Stop();
                form.Close();
            }
        }
        public void NewRound()  // NR
        {
            round++;
            connection.SentToAllClient("NR"+round.ToString());  // "NR;-;round;"    此輪為第round回
            for(int i = 0; i < connection.tcpClients.Count; i++)
            {
                if (connection.tcpClients[i.ToString()].isGameOver)
                {
                    // 向所有玩家回傳此玩家已淘汰
                    //應該沒必要connection.SentToAllClient(PO); // "NR;i;-;"  玩家i已淘汰
                }
                else
                {
                    // 向所有玩家回傳此未淘汰玩家位置
                    connection.SentToAllClient("PL" + i.ToString() + connection.tcpClients[i.ToString()].ROW.ToString() + connection.tcpClients[i.ToString()].COL.ToString() + ";");   // "PLiXY"    玩家i在新一局的座標
                }
            }
        }

        public void setBoom(int x, int y) { map.setBoom(x, y); }

        public void EndRound()  // ER   此輪結束
        {
            string message = "ER;";
            for(int i = 0; i < connection.tcpClients.Count; i++)
            {
                int row = connection.tcpClients[i.ToString()].ROW;
                int col = connection.tcpClients[i.ToString()].COL;
                if (map.MAP[row, col] == true)
                {
                    connection.tcpClients[i.ToString()].setGameOver();
                    connection.SentToAllClient("PO"+ i.ToString());  // "POi" 玩家i被炸彈炸到了 PO stands for PlayerOut
                }
            }
            map.clearBoom();
            //CheckNewRound();
        }

        public void CheckNewRound() // 檢查是否能進入下一局遊戲
        {
            int loser = 0;
            foreach (var kvp in connection.tcpClients)
            {
                string client_ID = kvp.Key;
                ClientState clientState = kvp.Value;
                if (clientState.isGameOver) { loser++; }
            }

            if (loser == connection.tcpClients.Count - 1) {
                //GameEnd(true);
                Stop = true;
            }
            else if(loser == connection.tcpClients.Count) {
                //GameEnd(false);
                ALL_DEAD = true;
                Stop = true;
            }
            //else { NewRound(); }
        }

        public void GameEnd(bool win)   // GE   遊戲結束
        {
            string message = "GE;";
            if (win)
            {
                foreach (var kvp in connection.tcpClients)
                {
                    string client_ID = kvp.Key;
                    ClientState clientState = kvp.Value;
                    if (!(clientState.isGameOver)) 
                    {
                        connection.SentToAllClient("GE"+client_ID);   // "GEclient_ID"  玩家ID獲勝
                        break; 
                    }
                }
            }
            else { connection.SentToAllClient("AD"); }  // "AD"  玩家全軍覆沒 AD for ALL DEAD

        }

        #region Send
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
        #endregion
    }
}
