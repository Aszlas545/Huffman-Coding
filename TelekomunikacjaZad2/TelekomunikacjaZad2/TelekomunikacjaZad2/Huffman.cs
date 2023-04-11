using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class Huffman  //Klasa przedstawia samą logike działania kodowania huffmana i tworzenie drzewa binarnego
    {
        List<Char> charList = new List<Char>();
        List<int> freqList = new List<int>();
        List<HuffmanDictionary> dictionaryList = new List<HuffmanDictionary>();
        internal List<HuffmanDictionary> DictionaryList { get => dictionaryList;}

        public void countFrequencies(string text)                       //Funkcja zliczająca wystąpnie każdego ze znaków aby utworzyć drzewo binarne huffmana     
        {
            freqList = new List<int>();                                 //Lista przechowująca chary bez powtórzeń
            charList = new List<Char>();                                //Lista przechowująca ich częstotliwości

            for (int i = 0; i < text.Length ; i++)                      //Dodawanie do listy charów których jeszcze w niej nie ma
            {
                if (!charList.Contains(text[i]))
                    charList.Add(text[i]);
            }
            
            for (int i = 0;i < charList.Count ; i++)                    //Dodawanie do listy częstotliwości każdego z charów z listy charów
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

        public HuffmanNode GenerateTree()                                       //Funkcja generująca drzewo binarne huffmana
        {
            HuffmanNode left, right, top;

            List<HuffmanNode> huffmanList = new  List<HuffmanNode>();

            for (int i = 0 ; i<charList.Count ; i++)
            {
                huffmanList.Add(new HuffmanNode(freqList[i], charList[i]));     //Stworzenie Listy z węzłami huffmana z użyciem list z poprzedniej funkcji
            }

            while (huffmanList.Count != 1)                                      //Pętla zatrzyma się aż zostanie tylko jeden node (korzeń drzewa)                                     
            {
                huffmanList.Sort(new CompareHuffmanNodes());                    //Posortowanie listy aby na przodzie znajdowały się najrzadziej występujące znaki
                left = huffmanList[0];
                huffmanList.Remove(left);
                right = huffmanList[0];
                huffmanList.Remove(right);


                top = new HuffmanNode(left.Frequency + right.Frequency, '$');  //Utworzenie nowego node'a nadrzędnego dla dwóch najrzadziej występujących

                top.Left = left;
                top.Right = right;

                huffmanList.Add(top);
            }

            return huffmanList[0];                                             //Korzeń drzewa
        }

        public void createDictionary(HuffmanNode root, string str)             //Funckcja rekursywnie dopisuje 0 i 1 aby utworzyć słownik kodowy w postaci możliwej do przedstawienia urzytkownikowi
        {
            if (root == null)
                return;

            if (root.Sign != '$')
                dictionaryList.Add(new HuffmanDictionary(root.Sign, str));
            createDictionary(root.Left, str + "0");
            createDictionary(root.Right, str + "1");
        }

        public string generateDictionary()                                              //Przekształcenie słownika na możliwy do wyświeltnia string
        {
            dictionaryList.Clear();
            createDictionary(GenerateTree(), "");
            dictionaryList.Sort(new CompareHuffmanDictionary());
            string str = string.Empty;
            for (int i = 0 ; i<dictionaryList.Count ; i++)
            {
                str += (dictionaryList[i].Sign + ": " + dictionaryList[i].Code + "\n");
            }
            return str;
        }

        public string getHuffmanString(string text, List<HuffmanDictionary> dictionary) //Zamiania wiadomości na ciąg 0 i 1 przedstawiony jako string dla wizualnego przedstawienia użytkownikowi
        {
            string str = "";

            for (int i = 0 ; i<text.Count(); i++)
            {
                str += dictionary.Where(f => f.Sign == text[i]).First().Code;
            }

            return str;
        }

        public string generateDictionary2(HuffmanNode root)                             //Funkcja tworząca String słownika kodowego z gotowego drzewa (otrzymanego w transmisji)
        {
            dictionaryList.Clear();
            createDictionary(root, "");
            dictionaryList.Sort(new CompareHuffmanDictionary());
            string str = string.Empty;
            for (int i = 0; i < dictionaryList.Count; i++)
            {
                str += (dictionaryList[i].Sign + ": " + dictionaryList[i].Code + "\n");
            }
            return str;
        }
    }
}
