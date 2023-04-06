using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikacja1
{
    internal class FileMenager
    {
        public byte[] readFile(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return bytes;
        }

        public void saveFile(byte[] data, string filePath)
           => File.WriteAllBytes(filePath, data);

        public string readText(string filePath) 
            => File.ReadAllText(filePath);

    }
}
