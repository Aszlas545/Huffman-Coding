using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class HuffmanDictionary
    {
        private char sign;
        private string code;

        public HuffmanDictionary(char sign, string code)
        {
            this.sign = sign;
            this.code = code;
        }

        public char Sign { get => sign; set => sign = value; }
        public string Code { get => code; set => code = value; }
    }
}
