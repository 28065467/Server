namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_ServerStart = new System.Windows.Forms.Button();
            this.list_LOG = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_GameSTART = new System.Windows.Forms.Button();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.list_Recv = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_IP = new System.Windows.Forms.TextBox();
            this.tbx_PORT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ServerStart
            // 
            this.btn_ServerStart.Location = new System.Drawing.Point(57, 28);
            this.btn_ServerStart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ServerStart.Name = "btn_ServerStart";
            this.btn_ServerStart.Size = new System.Drawing.Size(81, 41);
            this.btn_ServerStart.TabIndex = 0;
            this.btn_ServerStart.Text = "Server START";
            this.btn_ServerStart.UseVisualStyleBackColor = true;
            this.btn_ServerStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // list_LOG
            // 
            this.list_LOG.FormattingEnabled = true;
            this.list_LOG.ItemHeight = 12;
            this.list_LOG.Location = new System.Drawing.Point(11, 109);
            this.list_LOG.Margin = new System.Windows.Forms.Padding(2);
            this.list_LOG.Name = "list_LOG";
            this.list_LOG.Size = new System.Drawing.Size(504, 328);
            this.list_LOG.TabIndex = 1;
            this.list_LOG.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btn_GameSTART
            // 
            this.btn_GameSTART.Location = new System.Drawing.Point(183, 28);
            this.btn_GameSTART.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GameSTART.Name = "btn_GameSTART";
            this.btn_GameSTART.Size = new System.Drawing.Size(81, 41);
            this.btn_GameSTART.TabIndex = 5;
            this.btn_GameSTART.Text = "Game \r\nSTART";
            this.btn_GameSTART.UseVisualStyleBackColor = true;
            this.btn_GameSTART.Click += new System.EventHandler(this.btn_GameSTART_Click);
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.Location = new System.Drawing.Point(294, 28);
            this.btn_EXIT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(81, 41);
            this.btn_EXIT.TabIndex = 7;
            this.btn_EXIT.Text = "EXIT";
            this.btn_EXIT.UseVisualStyleBackColor = true;
            this.btn_EXIT.Click += new System.EventHandler(this.button5_Click);
            // 
            // list_Recv
            // 
            this.list_Recv.FormattingEnabled = true;
            this.list_Recv.ItemHeight = 12;
            this.list_Recv.Location = new System.Drawing.Point(519, 109);
            this.list_Recv.Margin = new System.Windows.Forms.Padding(2);
            this.list_Recv.Name = "list_Recv";
            this.list_Recv.Size = new System.Drawing.Size(465, 328);
            this.list_Recv.TabIndex = 8;
            this.list_Recv.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(167, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(694, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Recevied Message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(534, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Server IP";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(516, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Server PORT";
            // 
            // tbx_IP
            // 
            this.tbx_IP.Location = new System.Drawing.Point(646, 15);
            this.tbx_IP.Name = "tbx_IP";
            this.tbx_IP.Size = new System.Drawing.Size(100, 22);
            this.tbx_IP.TabIndex = 13;
            // 
            // tbx_PORT
            // 
            this.tbx_PORT.Location = new System.Drawing.Point(646, 53);
            this.tbx_PORT.Name = "tbx_PORT";
            this.tbx_PORT.Size = new System.Drawing.Size(100, 22);
            this.tbx_PORT.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 448);
            this.Controls.Add(this.tbx_PORT);
            this.Controls.Add(this.tbx_IP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_Recv);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.btn_GameSTART);
            this.Controls.Add(this.list_LOG);
            this.Controls.Add(this.btn_ServerStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ServerStart;
        private System.Windows.Forms.ListBox list_LOG;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_GameSTART;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.ListBox list_Recv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbx_IP;
        public System.Windows.Forms.TextBox tbx_PORT;
    }
}

