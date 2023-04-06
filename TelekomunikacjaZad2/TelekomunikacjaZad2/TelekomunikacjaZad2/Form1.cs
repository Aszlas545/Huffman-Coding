using Telekomunikacja1;

namespace TelekomunikacjaZad2
{
    public partial class Form1 : Form
    {
        FileMenager fileMenager = new FileMenager();
        Huffman huffman = new Huffman();
        public Form1()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            string text = fileMenager.readText("text.txt");
            Console.WriteLine(text);
            huffman.countFrequencies(text);
            huffman.generateDictionary();
            List<HuffmanDictionary> dictionary = huffman.DictionaryList;

            Console.WriteLine(huffman.getHuffmanString(text, dictionary));
        }
    }
}