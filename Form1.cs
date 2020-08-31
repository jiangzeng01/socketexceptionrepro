using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
	public partial class Form1 : Form
	{
		private static TcpListener listener;
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			listener = new TcpListener(IPAddress.Any, 4441);
			listener.Start(6);
			listener.BeginAcceptSocket(Listener_AcceptSocketCallback, null);
			label1.Text = "started listening";
		}
		private static void Listener_AcceptSocketCallback(IAsyncResult ar)
		{
			try
			{
				listener.EndAcceptSocket(ar);
			}
			catch (ObjectDisposedException ex)
			{
				MessageBox.Show("ObjectDisposedException on 3.1 and 5 prev");
				//catch on 3.1 and 5 prev
			}
			catch (Exception ex)
			{
				//catch on .net5 rc
				MessageBox.Show($"Catch on .net5 RC {ex.Message}");
			  	listener.BeginAcceptSocket(Listener_AcceptSocketCallback, null);
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			listener.Stop();
			label1.Text = "stopped";
		}
	}
}
