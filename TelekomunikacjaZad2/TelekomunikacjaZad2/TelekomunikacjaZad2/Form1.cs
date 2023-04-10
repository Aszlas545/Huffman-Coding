using System;
using System.Collections;
using System.Windows.Forms;
using Telekomunikacja1;
using static System.Net.Mime.MediaTypeNames;

namespace TelekomunikacjaZad2
{
    public partial class Form1 : Form
    {
        FileMenager fileMenager = new FileMenager();
        Huffman huffman = new Huffman();
        FileEncoder fileEncoder = new FileEncoder();
        FileReciever fileReciever = new FileReciever();
        FileSender fileSender = new FileSender();

        HuffmanNode tree = null;
        string bitCode = String.Empty;
        string text = String.Empty;
        string treeDictionary = String.Empty;

        public Form1()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            Console.WriteLine(Convert.ToInt32(Port2.Text));
        }

        public void networktesting()
        {

        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\Telekomunkacja\\TelekomunikacjaZad2\\TelekomunikacjaZad2\\TelekomunikacjaZad2\\bin\\Debug\\net6.0-windows";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                text = fileMenager.readText(selectedFileName);

                StringText.Text = text;
            }
        }

        private void CodeButton_Click(object sender, EventArgs e)
        {
            if (text != String.Empty)
            {
                huffman.countFrequencies(text);
                treeDictionary = huffman.generateDictionary();
                List<HuffmanDictionary> dictionary = huffman.DictionaryList;
                bitCode = huffman.getHuffmanString(text, dictionary);
                tree = huffman.GenerateTree();
                BitText.Text = bitCode;
                DicionaryText.Text = treeDictionary;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            byte[] send = fileEncoder.HuffmanEncoder(bitCode);
            Console.WriteLine("sums: " + string.Join(" ", send));
            if (text != String.Empty && IPAddr1.Text != "ip" && Port1.Text != "port")
            {
                string response = fileSender.send(IPAddr1.Text, Convert.ToInt32(Port1.Text), send);
                ErrorComms.Text = response;
            }
        }

        private void RecieveButtonClick(object sender, EventArgs e)
        {
            bitCode = fileReciever.recieveMessage(Convert.ToInt32(Port2.Text));
            StringText.Text = String.Empty;
            BitText.Text = bitCode;
            /*if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                byte[] file = fileMenager.readBytes(selectedFileName);
                bitCode = fileEncoder.getStringFromBytes(file);
                StringText.Text = String.Empty;
                BitText.Text = bitCode;
                DicionaryText.Text = treeDictionary;
            }*/
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            if (text != String.Empty)
            {
                StringText.Text = fileEncoder.HuffmanDecoder(bitCode, tree);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (text != String.Empty)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.OverwritePrompt = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileMenager.saveText(StringText.Text, saveFileDialog1.FileName);
                }
            }
        }

        private void StopTransferButton_Click(object sender, EventArgs e)
        {
            fileReciever.StopCommand = true;
            ErrorComms.Text = "Transmisja przerwana rêcznie";
        }
    }
}