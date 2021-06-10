using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\manitsoni\test\test.txt";
            string path2 = @"D:\manitsoni\test2\test.txt";

            bool IsAvailable = Directory.Exists(path);
            if (!IsAvailable)
            {
                Directory.Move(path, path2);
            }


            bool IsFileAvailable = File.Exists(path);

            if (!IsFileAvailable)
            {
                File.Move(path2, path);
            }
        }
    }
}
