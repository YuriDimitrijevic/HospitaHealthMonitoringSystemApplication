using HospitalHealthMonitoringShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDServerDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            CMDServer server = new CMDServer(SharedHelper.GetLocalIPAddress(), Int32.Parse(args[0]));
            Console.ReadLine();
        }
    }
}
