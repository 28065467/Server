using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Connection_Control;
using System.Net.Http.Headers;
using Game.Manager;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public const int PORT = 10000;
        private Connection connection;
        private GameManager gameManager;
        public Form1()
        {
            InitializeComponent();
            tbx_IP.Text = Connection.GetLocalIpAddress();
            //tbx_IP.Enabled = false;
            tbx_PORT.Text = PORT.ToString();
            //tbx_PORT.Enabled = false;
            list_LOG.Items.Add("The Server is ready to start");
            connection = new Connection(this); // 建立 Connection 物件
        }
        private void btn_GameSTART_Click(object sender, EventArgs e)// GameStart
        {
            gameManager = new GameManager(this,connection);

            gameManager.GameStartSet();
        }

        private void button1_Click(object sender, EventArgs e) // Server Start
        {
            connection.Start_Connecting();
            btn_ServerStart.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)//EXIT
        {
            Close();
        }

        public void ADD_TO_LOG(string message)
        {
            if (list_LOG.InvokeRequired)
            {
                list_LOG.Invoke((MethodInvoker)(() => list_LOG.Items.Add(message)));
            }
            else
            {
                list_LOG.Items.Add(message);
            }
        }
        public void ADD_TO_Recv(string message)
        {
            if (list_Recv.InvokeRequired)
            {
                list_Recv.Invoke((MethodInvoker)(() => list_Recv.Items.Add(message)));
            }
            else
            {
                list_Recv.Items.Add(message);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }



        private void btn_GameSTOP_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
