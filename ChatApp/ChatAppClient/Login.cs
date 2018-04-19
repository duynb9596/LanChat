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
				case "Connect":
					ConnectAction(mContent);
					break;
				case "Login":
					LoginAction(mContent);
					break;
				default:
					break;
			}
		}

		private void ConnectAction(string content)
		{
			if (content.Equals("Accepted"))
			{
				this.Invoke(new Action(() =>
				{
					txtServerIP.Enabled = false;
					btnConnect.Enabled = false;
					MessageBox.Show("Connect Succeeded!");
				}));
			}
		}

		private void LoginAction(string content)
		{
			if (!content.Equals("<<LoginFailed>>"))
			{
				this.Invoke(new Action(() =>
				{
					MessageBox.Show("Login Succeeded!");
					User userForm = new User(this);
					this.Hide();
					userForm.Show();
					userForm.ChangeLabelUsername(content);
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

					string str = "Connect|ABC|123|Server";

					Client.Send(str);

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

				try
				{
					string username = txtUsername.Text;
					string password = txtPassword.Text;
					string str = "Login|" + username + "|" + password + "|" + "server";
					Client.Send(str);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			else if (txtUsername.Text == "")
				MessageBox.Show("Username field cannot be empty!");
			else
				MessageBox.Show("Password field cannot be empty!");
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

		private void txtServerIP_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnConnect_Click(sender, e);
			}
		}

		private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnSignin_Click(sender, e);
			}
		}

		private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnSignin_Click(sender, e);
			}
		}
	}
}
