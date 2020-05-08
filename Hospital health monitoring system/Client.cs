using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HospitalHealthMonitoringSystem
{
    public class Client
    {
        public static string Connect(String server, int port, String message = nameof(string.Empty))
        {
            try
            {
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                Byte[] sentData = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(sentData, 0, sentData.Length);
                Console.WriteLine("Sent: {0}", message);

                var receivedData = new Byte[256];
                String response = String.Empty;
                Int32 bytes = stream.Read(receivedData, 0, receivedData.Length);
                response = System.Text.Encoding.ASCII.GetString(receivedData, 0, bytes);

                stream.Close();
                client.Close();

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }

            return string.Empty;
        }
    }
}
