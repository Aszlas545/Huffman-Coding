﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class CompareHuffmanDictionary : IComparer<HuffmanDictionary>  //Klasa której celem jest porównywanie listy aby wyświetlać ją po długości kodu 0 i 1 danego znaku
    {
        public int Compare(HuffmanDictionary x, HuffmanDictionary y) => x.Code.Length.CompareTo(y.Code.Length);
    }
}
