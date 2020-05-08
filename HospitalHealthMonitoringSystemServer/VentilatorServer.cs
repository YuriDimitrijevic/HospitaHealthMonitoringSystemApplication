using HospitalHealthMonitoringShared;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;

namespace HospitalHealthMonitoringSystemServer
{
    class VentilatorServer
    {
        private static VentilatorDeviceModel _vdm;

        TcpListener server = null;
        public VentilatorServer(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse("192.168.1.2");
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }

        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }
        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string hex = BitConverter.ToString(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Recieved data from client");
                    DeserializeDataFromClient(data);

                    string str = JsonConvert.SerializeObject(_vdm);
                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    stream.Write(reply, 0, reply.Length);
                    Console.WriteLine("Sent data to client");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }

        private static void DeserializeDataFromClient(string data)
        {
            BedModel bm = JsonConvert.DeserializeObject<BedModel>(data);
            if (bm.EditData)
            {
                _vdm.OxygenPercent = bm.VentilatorDevice.OxygenPercent;
                _vdm.AirPressure = bm.VentilatorDevice.AirPressure;
                _vdm.BreathDuration = bm.VentilatorDevice.BreathDuration;
                _vdm.BreathingRate = bm.VentilatorDevice.BreathingRate;
            }

            Random random = new Random();
            _vdm.BloodOxygenLevel = random.Next();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
