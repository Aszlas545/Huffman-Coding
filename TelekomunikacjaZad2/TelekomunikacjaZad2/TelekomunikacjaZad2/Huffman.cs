using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class Huffman
    {
        List<Char> charList = new List<Char>();
        List<int> freqList = new List<int>();
        List<HuffmanDictionary> dictionaryList = new List<HuffmanDictionary>();
        internal List<HuffmanDictionary> DictionaryList { get => dictionaryList;}

        public void countFrequencies(string text)
        {
            freqList = new List<int>();
            charList = new List<Char>();

            for (int i = 0; i < text.Length ; i++)
            {
                if (!charList.Contains(text[i]))
                    charList.Add(text[i]);
            }
            
            for (int i = 0;i < charList.Count ; i++)
            {
                Char c = charList[i];
                int freq = text.Count(f => f == c);
                freqList.Add(freq);
            }
            for (int i = 0  ; i < freqList.Count ; i++)
            {
                Console.WriteLine(charList[i] + ": " + freqList[i]);
            }            
        }

        public HuffmanNode GenerateTree()
        {
            HuffmanNode left, right, top;

            List<HuffmanNode> huffmanList = new  List<HuffmanNode>();

            for (int i = 0 ; i<charList.Count ; i++)
            {
                huffmanList.Add(new HuffmanNode(freqList[i], charList[i]));
            }

            while (huffmanList.Count != 1)
            {
                huffmanList.Sort(new CompareHuffmanNodes());
                left = huffmanList[0];
                huffmanList.Remove(left);
                right = huffmanList[0];
                huffmanList.Remove(right);


                top = new HuffmanNode(left.Frequency + right.Frequency, '$');

                top.Left = left;
                top.Right = right;

                huffmanList.Add(top);
            }

            return huffmanList[0];
        }

        private void createDictionary(HuffmanNode root, string str)
        {
            if (root == null)
                return;

            if (root.Sign != '$')
                dictionaryList.Add(new HuffmanDictionary(root.Sign, str));
            createDictionary(root.Left, str + "0");
            createDictionary(root.Right, str + "1");
        }

        public void generateDictionary()
        {
            createDictionary(GenerateTree(), "");
            dictionaryList.Sort(new CompareHuffmanDictionary());
            for (int i = 0 ; i<dictionaryList.Count ; i++)
            {
                Console.WriteLine(dictionaryList[i].Sign + ": " + dictionaryList[i].Code);
            }
        }

        public string getHuffmanString(string text, List<HuffmanDictionary> dictionary)
        {
            string str = "";

            for (int i = 0 ; i<text.Count(); i++)
            {
                str += dictionary.Where(f => f.Sign == text[i]).First().Code;
            }

            return str;
        }
    }
}
