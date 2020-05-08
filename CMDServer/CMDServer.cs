using HospitalHealthMonitoringShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CMDServer
{
	internal class CMDServer
	{
		private static CardioDeviceModel _cmd;

		private readonly TcpListener server;
		public static int Port { get; set; }
		public CMDServer(string ip, string port)
		{
			var intPort = int.Parse(port);
			var localAddr = IPAddress.Parse(ip);
			server = new TcpListener(localAddr, intPort);
			server.Start();
			StartListener();
		}

		public static void GenerateRandomData()
		{
			var random = new Random();
			_cmd.BloodPressure.Diastolic = random.Next();
			_cmd.BloodPressure.Systolic = random.Next();
			_cmd.HeartRate = random.Next();
		}		

		public void HandleDeivce(object obj)
		{
			var client = (TcpClient)obj;
			var stream = client.GetStream();
			var bytes = new byte[256];
			int i;
			try
			{
				while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
				{
					GenerateRandomData();
					var str = JsonConvert.SerializeObject(_cmd);
					var reply = Encoding.ASCII.GetBytes(str);
					stream.Write(reply, 0, reply.Length);
					Console.WriteLine("Sent data to client");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: {0}", e);
				client.Close();
			}
		}

		public void StartListener()
		{
			try
			{
				while (true)
				{
					Console.WriteLine("Waiting for a connection...");
					var client = server.AcceptTcpClient();
					Console.WriteLine("Connected!");
					var t = new Thread(HandleDeivce);
					t.Start(client);
				}
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
				server.Stop();
			}
		}
	}
}
