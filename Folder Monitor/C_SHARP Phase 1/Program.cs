using C_SHARP_Phase_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SHARP_Phase_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MonitorFolder("C:\\Temp", 2.5f);
            m.Start();

            while (true) { }
        }
    }
}
