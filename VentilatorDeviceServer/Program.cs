using HospitalHealthMonitoringShared;
using System;
using System.Linq;
using System.Threading;

namespace VentilatorDeviceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            VentilatorServer myserver = new VentilatorServer(SharedHelper.GetLocalIPAddress(), Int32.Parse(args[0]));
            

            Console.ReadLine();
        }

    }
}
