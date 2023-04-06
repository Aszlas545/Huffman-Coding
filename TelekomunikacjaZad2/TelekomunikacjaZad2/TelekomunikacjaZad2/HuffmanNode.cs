using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class HuffmanNode
    {
        private HuffmanNode? left, right;
        private int frequency;
        private char sign;

        public HuffmanNode(int frequency, char sign)
        {
            left = right = null;
            this.frequency = frequency;
            this.sign = sign;
        }

        public char Sign { get => sign; set => sign = value; }
        public int Frequency { get => frequency; set => frequency = value; }
        internal HuffmanNode? Left { get => left; set => left = value; }
        internal HuffmanNode? Right { get => right; set => right = value; }
    }
}
