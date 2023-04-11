using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikacja1
{
    internal class FileMenager      //Prosta klasa wykorzystująca dobroci klasy File zapisująca i odczytująca z pliku
    {
        public byte[] readBytes(string path) { return File.ReadAllBytes(path); }                    //odczyt bajtów

        public void saveBytes(byte[] data, string filePath) => File.WriteAllBytes(filePath, data);  //zapis bajtów

        public string readText(string filePath) => File.ReadAllText(filePath);                      //odczyt textu

        public void saveText(string data, string filePath) { File.WriteAllText(filePath, data); }   //zapis textu
    }
}
