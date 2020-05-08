using System;
using System.Threading;

namespace HospitalHealthMonitoringSystemServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t = new Thread(delegate ()
            //{
            //    CMDServer myserver = new CMDServer(VentilatorServer.GetLocalIPAddress(), 13000);
            //});
            //t.Start();

            CMDServer myserver = new CMDServer(VentilatorServer.GetLocalIPAddress(), 13000);
            CMDServer myserver1 = new CMDServer(VentilatorServer.GetLocalIPAddress(), 13000);
            CMDServer myserver2 = new CMDServer(VentilatorServer.GetLocalIPAddress(), 13000);
            CMDServer myserver3 = new CMDServer(VentilatorServer.GetLocalIPAddress(), 13000);

        }
    }
}
