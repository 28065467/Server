using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using Client.Manager;

namespace WindowsFormsApp1.Connection_Control
{
    internal class Connection
    {
        public Dictionary<string ,ClientState> tcpClients;
        private Form1 form;
        private TcpListener listener;
        private Thread connectionThread;
        private int ID = 1;
        public Connection(Form1 form)
        {
            tcpClients = new Dictionary<string, ClientState>();
            this.form = form;
            listener = new TcpListener(IPAddress.Parse(form.tbx_IP.Text), 10000);
            IPEndPoint ipe = (IPEndPoint)listener.LocalEndpoint;
            form.ADD_TO_LOG("Listening At " + ipe.Address  + ":" + ipe.Port);
        }

        public static string GetLocalIpAddress()
        {
            string ipAddress = string.Empty;
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return "127.0.0.1";
        }

        public void Start_Connecting()
        {
            listener.Start();
            form.ADD_TO_LOG("Waiting For Connections");
            connectionThread = new Thread(AcceptConnections);
            connectionThread.IsBackground = true;
            connectionThread.Start();
        }
        private void AcceptConnections()
        {
            TcpClient temp;
            while (true)
            {
                temp = listener.AcceptTcpClient();
                if (temp.Connected)
                {
                    tcpClients.Add(ID.ToString(),new ClientState(temp));
                    SentToSingleClient(ID, ID.ToString());
                    form.ADD_TO_LOG("Client " + ID + " :" + temp.Client.RemoteEndPoint + " is joined");
                    //SentToSingleClient(ID,ID.ToString());
                    connectionThread = new Thread(Client_Listening);
                    connectionThread.IsBackground = true;
                    connectionThread.Start(temp);
                    ID++;
                }
            }
        }
        private void Client_Listening(object clientObj)
        {
            TcpClient listeningSoc = (TcpClient)clientObj;
            NetworkStream networkStream = listeningSoc.GetStream(); 
            //listeningSoc.Blocking = false;
            //Thread listeningThread = client_thread;
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
                            form.ADD_TO_LOG("Fail to Read");
                        }
                        else {
                            string Message_From_Client = Encoding.UTF8.GetString(buffer, 0, BytesReaded);
                            form.ADD_TO_Recv("Sucessfully Receive " + Message_From_Client + " Form Client");
                        }
                    }

                }
                catch(Exception ex)
                {
                    form.ADD_TO_LOG("Error : " + ex.Message);
                }
            }
        }
        public void SentToAllClient(string Mesaage)
        {
            byte[] data = Encoding.UTF8.GetBytes(Mesaage);
            foreach (var kvp in tcpClients)
            {
                string Client_ID = kvp.Key;
                TcpClient client = tcpClients[Client_ID].tcpClient;
                NetworkStream networkStream = client.GetStream();
                try
                {
                    if (networkStream.CanWrite)
                    {
                        networkStream.Write(data, 0, data.Length);
                        //form.ADD_TO_LOG("Message " + Mesaage + " is sent to Client " + Client_ID);
                    }
                    else
                        form.ADD_TO_LOG("Fail to sent to Client " + Client_ID);
                }
                catch(IOException ex)
                {
                    form.ADD_TO_LOG(ex.Message);
                }
            }

        }
        public void SentToSingleClient(int Client_ID, string Mesaage)
        {
            byte[] data = Encoding.UTF8.GetBytes(Mesaage);
            TcpClient client = tcpClients[Client_ID.ToString()].tcpClient;
            NetworkStream networkStream = client.GetStream();
            try
            {
                if (networkStream.CanWrite)
                {
                    networkStream.Write(data, 0, data.Length);
                    //form.ADD_TO_LOG("Message " + Mesaage + " is sent to Client " + Client_ID);
                }
                else
                    form.ADD_TO_LOG("Fail to sent to Client " + Client_ID);
            }
            catch (IOException ex)
            {
                form.ADD_TO_LOG(ex.Message);
            }
        }

        
    }
}
