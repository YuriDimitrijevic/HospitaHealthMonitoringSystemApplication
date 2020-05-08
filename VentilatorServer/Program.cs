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
            VentilatorServer myserver = new VentilatorServerDevice(SharedHelper.GetLocalIPAddress(), Int32.Parse(args[0]));
            Console.ReadLine();
        }
    }
}
