using HospitalHealthMonitoringShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VentilatorServerDevice
{
    public class VentilatorServer
    {
        private static VentilatorDeviceModel _vdm = new VentilatorDeviceModel();

        private readonly TcpListener server;

        public VentilatorServer(string ip, int port)
        {
            var localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }

        public void HandleDevice(object obj)
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
                    DeserializeDataFromClient(data);

                    var str = JsonConvert.SerializeObject(_vdm);
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
                    var t = new Thread(HandleDevice);
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }

        private static void DeserializeDataFromClient(string data)
        {
            var random = new Random();

            if (data != "Empty")
            {
                var vd = JsonConvert.DeserializeObject<VentilatorDeviceModel>(data);
                _vdm.OxygenPercent = vd.OxygenPercent;
                _vdm.AirPressure = vd.AirPressure;
                _vdm.BreathDuration = vd.BreathDuration;
                _vdm.BreathingRate = vd.BreathingRate;
                _vdm.PortNumber = vd.PortNumber;
            }

            _vdm.BloodOxygenLevel = random.Next(1000, 3000);
        }
    }
}
