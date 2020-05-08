using HospitalHealthMonitoringShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMDServerDevice
{
    public class CMDServer
    {
        private static CardioDeviceModel _cmd = new CardioDeviceModel();

        private readonly TcpListener server;
        public static int Port { get; set; }
        public CMDServer(string ip, int port)
        {
            var localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
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
                    var hex = BitConverter.ToString(bytes);
                    var data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Recieved data from client");
                    DeserializeDataFromClient();

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

        public static void DeserializeDataFromClient()
        {
            var random = new Random();
            _cmd.BloodPressure.Diastolic = random.Next(20, 150);
            _cmd.BloodPressure.Systolic = random.Next(60, 200);
            _cmd.HeartRate = random.Next(25, 140);
        }
    }
}
