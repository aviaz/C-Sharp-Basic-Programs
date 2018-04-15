using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using C_SHARP_Phase_1.Infrastructures;

namespace C_SHARP_Phase_1.Models
{
    public class MonitorFolder
    {
        /// <summary>
        /// The folder path
        /// </summary>
        private string _path;
        /// <summary>
        /// Size of folder in mega-bytes
        /// </summary>
        private float _size;
        /// <summary>
        /// Interval for checking the folder in seconds
        /// </summary>
        private double _interval;
        /// <summary>
        /// Timer for we don't waste CPU time
        /// </summary>
        private Timer _timer;

        public MonitorFolder(string path, float size, double interval = 1.0f)
        {
            _path = path;
            _size = size;
            _interval = interval;
            _timer = new Timer(Math.Round(_interval * 1000));
            _timer.Elapsed += (sender, e) =>
            {
                var currSize = GetFolderSize(_path).ToMegaBytes();
                if (currSize >= _size)
                {
                    Console.WriteLine($"The folder has exceeded the {_size:F2}MB");
                }
                else
                {
                    // Console.WriteLine($"The folder size is {currSize:F2}MB");
                }
            };
        }

        /// <summary>
        /// Start monitor the folder
        /// </summary>
        public void Start()
        {
            _timer.Start();
            Console.WriteLine($"The monitor has started on folder: {_path}");
        }

        /// <summary>
        /// Stop monitor the folder
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            Console.WriteLine("The monitor has stoped");
        }

        /// <summary>
        /// Get folder size in KB
        /// </summary>
        /// <returns></returns>
        private long GetFolderSize(string path)
        {
            long size = 0;
            var di = new DirectoryInfo(path);

            foreach (var file in di.GetFiles())
            {
                size += file.Length;
            }
            foreach (var dir in di.GetDirectories())
            {
                size += GetFolderSize(dir.FullName);
            }
            return size;
        }
    }
}
