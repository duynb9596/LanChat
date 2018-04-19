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
using System.Threading;
using System.IO;
using System.Configuration;
using ChatApp_Server.Controller;

namespace ChatApp_Server
{
	public partial class Server : Form
	{
		private const int PORT_NUMBER = 50000;
		private const int BUFFER_SIZE = 1024;
		//static ASCIIEncoding encoding = new ASCIIEncoding();
		//public static List<TcpClient> clients = new List<TcpClient>();
		//static TcpListener listener;
		private Listener listener;
		public List<Socket> clients = new List<Socket>();
		ServerController serverController;

		public Server()
		{
			InitializeComponent();
			listener = new Listener(PORT_NUMBER);
			listener.SocketAccepted += listener_SocketAccepted;
			serverController = new ServerController();
		}

		private void listener_SocketAccepted(Socket socket)
		{
			var client = new Client(socket);
			client.Received += client_Received;
			client.Disconnected += client_Disconnected;
			string ip = client.Ip.ToString();
			Invoke(new Action(() =>
			{
				var item = new ListViewItem(ip); // ip
				item.SubItems.Add("<<undefined>>"); // nickname
				item.Tag = client;
				livActiveUser.Items.Add(item);
			}));
			clients.Add(socket);
			string message = "Connect|Server|Accepted|" + ip;
			client.Send(message);
			AppendText_txtOutgoingMessage(ip, message);
			
			AppendText_txtConnectMessage(ip, "A client connect to Server on " + socket.RemoteEndPoint.ToString());
		}

		private void client_Disconnected(Client sender)
		{
			Invoke(new Action(() =>
			{
				for (int i = 0; i < livActiveUser.Items.Count; i++)
				{
					var client = livActiveUser.Items[i].Tag as Client;
					if (client.Ip == sender.Ip)
					{
						livActiveUser.Items.RemoveAt(i);
						AppendText_txtConnectMessage(sender.Ip.ToString(), "Client " + sender.Ip.ToString() + " has disconnected!");
					}
				}
			}));
		}

		private void client_Received(Client sender, byte[] data)
		{
			var message = Encoding.ASCII.GetString(data).Split('|');
			string mType = message[0];
			string mSender = message[1];
			string mContent = message[2];
			string mRecipient = message[3];
			var fullMessage = Encoding.ASCII.GetString(data);
			string ip = sender.Ip.ToString();
			AppendText_txtIncomingMessage(ip, fullMessage);
			switch (mType)
			{
				case "Login":
					LoginAction(sender, mSender, mContent);
					break;
				case "PrivateMessage":
					PrivateMessage();
					break;
				default:
					break;
			}

		}

		private void LoginAction(Client sender, string username, string password)
		{
			string message;
			string ip = sender.Ip.ToString();
			if(serverController.CheckLogin(username, password))
			{
				message = "Login|Server|" + username + "|" + sender.Ip.ToString();
				Invoke(new Action(() =>
				{
					for (int i = 0; i < livActiveUser.Items.Count; i++)
					{
						var item = livActiveUser.Items[i];
						if (ip == item.SubItems[0].Text)
						{
							item.SubItems[1].Text = username;
						}
					}		
				}));
				Broadcast("NewActiveUser|Server|" + username + "|<<AllUsers>>");
				AppendText_txtOutgoingMessage("<<AllUsers>>", "NewActiveUser|Server|" + username + "|<<AllUsers>>");
				sender.Send(message);
				SendListUsers(sender, username);
			}
			else
			{
				message = "Login|Server|<<LoginFailed>>|" + sender.Ip.ToString();
				sender.Send(message);
			}	
			AppendText_txtOutgoingMessage(ip, message);
		}

		private void AppendText_txtConnectMessage(string recipient, string message)
		{
			Invoke(new Action(() => txtConnectMessage.AppendText(System.DateTime.Now + ":\n" + message)));
			Invoke(new Action(() => txtConnectMessage.AppendText(Environment.NewLine + Environment.NewLine)));
		}

		private void AppendText_txtIncomingMessage(string recipient, string message)
		{
			Invoke(new Action(() => txtIncomingMessage.AppendText(System.DateTime.Now + ":\nFrom " + recipient + ": ")));
			Invoke(new Action(() => txtIncomingMessage.AppendText(message)));
			Invoke(new Action(() => txtIncomingMessage.AppendText(Environment.NewLine + Environment.NewLine)));
		}

		private void AppendText_txtOutgoingMessage(string recipient, string message)
		{
			Invoke(new Action(() => txtOutgoingMessage.AppendText(System.DateTime.Now + ":\nTo " + recipient + ": ")));
			Invoke(new Action(() => txtOutgoingMessage.AppendText(message)));
			Invoke(new Action(() => txtOutgoingMessage.AppendText(Environment.NewLine + Environment.NewLine)));
		}

		private void PrivateMessage()
		{

		}

		private void Server_Load(object sender, EventArgs e)
		{
			listener.Start();
			txtConnectMessage.AppendText(System.DateTime.Now + ":\nServer started!\n\n");
		}

		private void livActiveUser_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void SendListUsers(Client sender, string recipient)
		{
			string mContent = "";
			Invoke(new Action(() =>
			{
				foreach (ListViewItem itemRow in this.livActiveUser.Items)
				{
					mContent += itemRow.SubItems[1].Text + "/";
				}
			}));
			mContent += "<<null>>";
			
			string message = "ListUsers|Server|" + mContent + "|" + recipient;
			sender.Send(message);
			AppendText_txtOutgoingMessage(recipient, message);
		}

		private void Broadcast(string message)
		{
			for (int i = 0; i < clients.Count; i++)
			{
				try
				{
					clients[i].Send(Encoding.ASCII.GetBytes(message));
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		//private void StartServer()
		//{
		//	try
		//	{
		//		IPAddress IP = IPAddress.Parse("127.0.0.1");
		//		listener = new TcpListener(IP, PORT_NUMBER);
		//		listener.Start();

		//		richtxtServer.AppendText("Server started on " + listener.LocalEndpoint + "\n");
		//		richtxtServer.AppendText("Wait for client connection....!\n");

		//		for (int i = 0; i < 5; i++)
		//		{			
		//			Thread t = new Thread(new ThreadStart(Service));
		//			t.Start();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("Error " + ex.Message);
		//	}
		//}

		//public void Service(){


		//	while (true){
		//		Socket socket = listener.AcceptSocket();
		//		socket.SetSocketOption(SocketOptionLevel.Socket,
		//				SocketOptionName.ReceiveTimeout, 10000);
		//		//soc.SetSocketOption(SocketOptionLevel.Socket,
		//		//        SocketOptionName.ReceiveTimeout,10000);
		//		//richtxtServer.AppendText("A client connect to Server on " + socket.RemoteEndPoint + "\n");
		//		Invoke(new Action(() => richtxtServer.AppendText("A client connect to Server on " + socket.RemoteEndPoint + "\n")));
		//		try
		//		{
		//			byte[] data = new byte[BUFFER_SIZE];
		//			socket.Receive(data);
		//			var message = Encoding.ASCII.GetString(data).Split('|');
		//			string fullMessage = Encoding.ASCII.GetString(data);
		//			Invoke(new Action(() => richtxtServer.AppendText(fullMessage)));
		//			Invoke(new Action(() => richtxtServer.AppendText(Environment.NewLine)));

		//		}
		//		catch(Exception e){
		//		}
		//		socket.Close();
		//	}
		//}

		//private void button1_Click(object sender, EventArgs e)
		//      {
		//          StartServer();
		//      }
	}
}
