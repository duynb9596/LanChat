using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatAppClient
{
    public partial class Login : Form
    {
        private const int PORT_NUMBER = 50000;
        private const int BUFFER_SIZE = 1024;
        static ASCIIEncoding encoding = new ASCIIEncoding();
		//public TcpClient client;
		//public Stream stream;
		public ClientSocket Client { get; set; }

        public Login()
        {
			Client = new ClientSocket();
			Client.Received += client_Received;
            InitializeComponent();
        }

		public void client_Received(ClientSocket cs, string received)
		{
			var message = received.Split('|');
			string mType = message[0];
			string mSender = message[1];
			string mContent = message[2];
			string mRecipient = message[3];
			switch(mType)
			{
				case "Login":
					LoginAction(mContent, mRecipient);
					break;
				default:
					break;
			}
		}

		private void LoginAction(string content, string IP)
		{
			if (content.Equals("LoginSucceeded"))
			{
				this.Invoke(new Action(() =>
				{
					MessageBox.Show("Login Succeeded!");
					ChatZone chatZone = new ChatZone();
					this.Hide();
					chatZone.ChangeLabelName(IP);
					chatZone.Show();
				}));


			}
			else
			{
				MessageBox.Show("Incorrect username or password! Please try again!");
			}			
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (txtServerIP.Text != "")
			{
				//client = new TcpClient();
				
				// 1. connect
				try
				{
					string serverIP = txtServerIP.Text;
					Client.Connect(serverIP, PORT_NUMBER);
					//stream = client.GetStream();

					string str = "Connect|ABC|123|Server";

					// 2. send
					Client.Send(str);

					//stream.Write(data, 0, data.Length);

					//client.Close();

					//MessageBox.Show("Login success!");
					//ChatZone chatZone = new ChatZone();
					//this.Hide();
					//chatZone.Show();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			else
			{
				MessageBox.Show("Server IP cannot be left empty!");
			}
		}

		private void btnSignin_Click(object sender, EventArgs e)
		{
			if (txtUsername.Text != "" && txtPassword.Text != "")
			{

				// 1. connect
				try
				{
					string username = txtUsername.Text;
					string password = txtPassword.Text;

					string str = "Login|" + username + "|" + password + "|" + "server";

					// 2. send
					//byte[] data = encoding.GetBytes(str);
					//stream.Write(data, 0, data.Length);

					Client.Send(str);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			else
			{
				MessageBox.Show("Username and Password cannot be left empty!");
			}
		}

		private void txtServerIP_Click(object sender, EventArgs e)
		{
			txtServerIP.Text = "";
		}

		private void txtUsername_Click(object sender, EventArgs e)
		{
			txtUsername.Text = "";
		}

		private void txtPassword_Click(object sender, EventArgs e)
		{
			txtPassword.Text = "";
		}
	}
}
