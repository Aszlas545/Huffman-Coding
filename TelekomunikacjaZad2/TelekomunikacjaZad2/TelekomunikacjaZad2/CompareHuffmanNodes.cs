using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class CompareHuffmanNodes : IComparer<HuffmanNode>
    {
        public int Compare(HuffmanNode x, HuffmanNode y) => x.Frequency.CompareTo(y.Frequency);
    }
}
