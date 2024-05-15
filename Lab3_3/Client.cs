using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Lab3_3
{
    public partial class Client : Form
    {
        TcpClient client;
        NetworkStream stream;
        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 8080);
                stream = client.GetStream();
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Error: " + ex.Message + "\n");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                
                string message = "From client: "+richTextBox1.Text + "\n";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Error: " + ex.Message + "\n");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                
                string message =": quit\n";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                this.Close();
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Error: " + ex.Message + "\n");
            }
        }

      
    }
}