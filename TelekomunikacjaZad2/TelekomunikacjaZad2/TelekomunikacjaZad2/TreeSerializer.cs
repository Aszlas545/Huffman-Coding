using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class TreeSerializer
    {
        string text = string.Empty;
        string frequencies = string.Empty;
        HuffmanNode tree = new HuffmanNode();
        List<int> freqList = new List<int>();
        List<char> signList = new List<char>();
        List<HuffmanNode> nodeList = new List<HuffmanNode>();
        int deserializeInt = 0;

        public string Text { get => text; set => text = value; }
        public string Frequencies { get => frequencies; set => frequencies = value; }
        internal HuffmanNode Tree { get => tree; set => tree = value; }
        public List<int> FreqList { get => freqList; set => freqList = value; }
        public List<char> SignList { get => signList; set => signList = value; }
        internal List<HuffmanNode> NodeList { get => nodeList; set => nodeList = value; }

        public void serialize(HuffmanNode root)
        {
            if (root == null)
            {
                text += "&" + "^";
                frequencies += "&" + "^";
                return;
            }
            text += root.Sign + "^";
            frequencies += Convert.ToString(root.Frequency) + "^";
            serialize(root.Left);
            serialize(root.Right);
        }
        
        public void makeLists(string txt, string freq)
        {
            signList.Clear();
            freqList.Clear();

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] != '^')
                {
                    signList.Add(txt[i]);
                }
            }
            int k;
            for (int i = 0; i < freq.Length; i = k+1)
            {
                k = findFrequency(freq, i);
                string myInt = freq.Substring(i, k-i);
                if (myInt != "&")
                {
                    freqList.Add(Convert.ToInt32(myInt));
                }
            }
        }

        private int findFrequency(string freq, int i)
        {
            for (int j = i; j < freq.Length; j++)
            {
                if (freq[j] == '^')
                {
                    return j;
                }
            }
            return 0;
        }

        public HuffmanNode deserialize()
        {
            deserializeInner1();
            tree = deserializeInner2();
            return tree;
        }

        public void deserializeInner1()
        {
            nodeList.Clear();
            int j = 0;
            for (int i = 0; i < signList.Count; i++, j++)
            {
                if (signList[i] == '&')
                {
                    i++;
                    nodeList.Add(null);
                    if (signList[i] == '&')
                    {
                        i++;
                        nodeList.Add(null);
                    }
                }
                if (j == freqList.Count)
                {
                    return;
                }
                int frq = freqList[j];
                char sig = signList[i];
                HuffmanNode node = new HuffmanNode(freqList[j], signList[i]);
                nodeList.Add(node);
            }
        }
        public HuffmanNode deserializeInner2()
        {
            if (nodeList[deserializeInt]==null)
            {
                return null;
            }
            HuffmanNode root = nodeList[deserializeInt];
            deserializeInt++;
            root.Left = deserializeInner2();
            deserializeInt++;
            root.Right = deserializeInner2();
            return root;
        }
    }
}
