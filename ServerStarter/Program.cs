using HospitalHealthMonitoringShared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ServerStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (Bed item in icubedsdescriptor)
            //{
                Process.Start($"..\\..\\..\\..\\VentilatorDeviceServer\\bin\\Debug\\netcoreapp3.1\\VentilatorDeviceServer.exe", "5000");
                Process.Start($"..\\..\\..\\..\\CMDServer\\bin\\Debug\\netcoreapp3.1\\CMDServer.exe");

            //}
        }
    }
}
