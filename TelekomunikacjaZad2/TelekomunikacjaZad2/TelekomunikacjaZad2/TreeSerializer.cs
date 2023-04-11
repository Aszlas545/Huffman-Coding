using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class TreeSerializer   //Klasa serializująca drzewo do łańcucha znaków i odwracająca proces (po odebraniu)
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

        public void serialize(HuffmanNode root)     //Funkcja tworząca 2 stringi z drzewa binarnego (jeden dla znaków, drugi dla częstotliwości)
        {                                           //Jeżeli następnym węzłem jest null dopisujemy '&' przy zmianie węzła dopisujemy '^'
            if (root == null)   
            {
                text += "&" + "^";
                frequencies += "&" + "^";
                return;
            }
            text += root.Sign + "^";
            frequencies += Convert.ToString(root.Frequency) + "^";
            serialize(root.Left);                   //Wykonywanie rekusywne aż obsłużone zostaną wszystkie węzły drzewa
            serialize(root.Right);
        }
        
        public void makeLists(string txt, string freq)  //Funckja tworzy listy ze stringów odebranych w przesyłaniue (Socked)
        {                                               //W skrócie usuwa z nich niepotrzebne znaki ^ oraz &
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

        private int findFrequency(string freq, int i)   //Funckja która znajduje w ile znakach charów mieści się liczba (node.frequency)
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

        public HuffmanNode deserialize()        //użycie rekursywnej deserializacji stringa i zwórcenie drzewa binarnego
        {
            deserializeInner1();
            tree = deserializeInner2();
            return tree;
        }

        public void deserializeInner1()         //Zamiana charów i intów z list utworzonych z otrzymanych w przesyle stringów na liste nodów
        {
            nodeList.Clear();
            int j = 0;
            for (int i = 0; i < signList.Count; i++, j++)
            {
                if (signList[i] == '&')         //pomijanie i inkrementacji inkerementatora gdy wartość ma byc nullem
                {
                    i++;
                    nodeList.Add(null);
                    if (signList[i] == '&')
                    {
                        i++;
                        nodeList.Add(null);
                    }
                }
                if (j == freqList.Count)        //Warunek przerwania (częstotliwości będzie mniej niż znaków bo w liście znaków zakodowane jest gdzie są nulle
                {
                    return;
                }
                int frq = freqList[j];
                char sig = signList[i];
                HuffmanNode node = new HuffmanNode(freqList[j], signList[i]);
                nodeList.Add(node);
            }
        }
        public HuffmanNode deserializeInner2()  //rekursywna deserlalizacja (tworzenie drzewa) z listy nodów utworzonej wcześniej
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
