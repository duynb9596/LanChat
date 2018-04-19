using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppClient
{
	public partial class User : Form
	{
		Login _loginForm;
		public User(Login loginForm)
		{
			_loginForm = loginForm;
			_loginForm.Client.Received += client_Received;
			InitializeComponent();
		}

		public void client_Received(ClientSocket cs, string received)
		{
			var message = received.Split('|');
			string mType = message[0];
			string mSender = message[1];
			string mContent = message[2];
			string mRecipient = message[3];
			switch (mType)
			{
				case "NewActiveUser":
					NewActiveUserAction(mContent);
					break;
				case "ListUsers":
					ListUsersAction(mContent);
					break;
				default:
					break;
			}
		}

		private void NewActiveUserAction(string username)
		{
			this.Invoke(new Action(() =>
			{
				bool isExist = false;
				for (int i = 0; i < livUsers.Items.Count; i++)
				{
					if (livUsers.Items[i].ToString() == username)
					{
						isExist = true;
						break;
					}
				}
				if (!isExist)
				{
					var item = new ListViewItem(username); // ip
					livUsers.Items.Add(item);
				}
			}));
		}

		private void ListUsersAction(string data)
		{
			var listUsers = data.Split('/');
			this.Invoke(new Action(() =>
			{
				for (int i = 0; i < listUsers.Length; i++)
				{
					if (listUsers[i] != "<<null>>" && listUsers[i] != lblUsername.Text)
					{
						var item = new ListViewItem(listUsers[i]);
						livUsers.Items.Add(item);
					}
				}
			}));	
		}

		public void ChangeLabelUsername(string name)
		{
			lblUsername.Text = name;
		}

		private void User_FormClosed(object sender, FormClosedEventArgs e)
		{
			_loginForm.Close();
		}
	}
}
