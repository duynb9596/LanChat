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
	public partial class PrivateChat : Form
	{
		User _userForm;
		string _username;
		string _target;
		ClientSocket Client;

		public PrivateChat(User userForm, string username, string target)
		{
			InitializeComponent();
			_userForm = userForm;
			_username = username;
			_target = target;
			lblUsername.Text = _target;
			_userForm._loginForm.Client.Received += client_Received;
			Client = _userForm._loginForm.Client;
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
				case "Connect":
					PrivateMessageAction(mContent);
					break;
				default:
					break;
			}
		}

		private void PrivateMessageAction(string content)
		{
			txtChatArea.AppendText(content);
			txtChatArea.AppendText(Environment.NewLine);
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			string message = "PrivateMessage|" + _username + "|" + txtInputMessage.Text + "|" + _target;
			Client.Send(message);
			txtChatArea.AppendText(txtInputMessage.Text);
			txtChatArea.AppendText(Environment.NewLine);
		}
	}
}
