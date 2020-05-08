using HospitalHealthMonitoringShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentilatorServerDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            VentilatorServer server = new VentilatorServer(SharedHelper.GetLocalIPAddress(), Int32.Parse(args[0]));
            Console.ReadLine();
        }
    }
}
