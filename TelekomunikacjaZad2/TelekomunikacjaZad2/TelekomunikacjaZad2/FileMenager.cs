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
        public byte[] readBytes(string path) { return File.ReadAllBytes(path); }

        public void saveBytes(byte[] data, string filePath) => File.WriteAllBytes(filePath, data);

        public string readText(string filePath) => File.ReadAllText(filePath);

        public void saveText(string data, string filePath) { File.WriteAllText(filePath, data); }
    }
}
