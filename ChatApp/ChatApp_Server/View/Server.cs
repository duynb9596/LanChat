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
			clients.Add(socket);
			Invoke(new Action(() => richtxtServer.AppendText("A client connect to Server on " + socket.RemoteEndPoint + "\n")));
		}

		private void client_Disconnected(Client sender)
		{
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
			Invoke(new Action(() => richtxtServer.AppendText(ip + ": " )));
			Invoke(new Action(() => richtxtServer.AppendText(fullMessage)));
			Invoke(new Action(() => richtxtServer.AppendText(Environment.NewLine)));
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
			if(serverController.CheckLogin(username, password))
			{
				sender.Send("Login|Server|LoginSucceeded|" + sender.Ip);
			}
			else
			{
				sender.Send("Login|Server|LoginFailed|" + sender.Ip);
			}
		}

		private void PrivateMessage()
		{

		}

		private void Server_Load(object sender, EventArgs e)
		{
			listener.Start();
			richtxtServer.AppendText("Server started!\n");
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
