using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppClient
{
	public class ClientSocket
	{
		readonly Socket _socket;
		public delegate void ReceivedEventHandler(ClientSocket cs, string received);
		public event ReceivedEventHandler Received = delegate { };
		public event EventHandler Connected = delegate { };
		public delegate void DisconnectedEventHandler(ClientSocket cs);
		public event DisconnectedEventHandler Disconnected = delegate { };
		bool _connected;

		public ClientSocket()
		{
			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		public void Connect(string ip, int port)
		{
			try
			{
				var ep = new IPEndPoint(IPAddress.Parse(ip), port);
				_socket.BeginConnect(ep, ConnectCallback, _socket);
			}
			catch { }
		}

		public void Close()
		{
			_socket.Dispose();
			_socket.Close();
		}

		void ConnectCallback(IAsyncResult ar)
		{
			try
			{
				_socket.EndConnect(ar);
				_connected = true;
				Connected(this, EventArgs.Empty);
				var buffer = new byte[_socket.ReceiveBufferSize];
				_socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReadCallback, buffer);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Cannot find any server with this IP!\nPlease try again or check your connection!");
			}	
		}

		private void ReadCallback(IAsyncResult ar)
		{
			var buffer = (byte[])ar.AsyncState;
			var rec = _socket.EndReceive(ar);
			if (rec != 0)
			{
				var data = Encoding.ASCII.GetString(buffer, 0, rec);
				Received(this, data);
			}
			else
			{
				Disconnected(this);
				_connected = false;
				Close();
				return;
			}
			_socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReadCallback, buffer);
		}

		public void Send(string data)
		{
			try
			{
				var buffer = Encoding.ASCII.GetBytes(data);
				_socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, buffer);
			}
			catch { Disconnected(this); }
		}

		void SendCallback(IAsyncResult ar)
		{
			_socket.EndSend(ar);
		}
	}
}
