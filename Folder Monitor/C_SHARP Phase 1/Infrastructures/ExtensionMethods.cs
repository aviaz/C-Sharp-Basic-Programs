using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SHARP_Phase_1.Infrastructures
{
    public static class ExtensionMethods
    {
        public static double ToMegaBytes(this long bytes)
        {
            return (double)(bytes / (1024.0 * 1024.0));
        }
    }
}
