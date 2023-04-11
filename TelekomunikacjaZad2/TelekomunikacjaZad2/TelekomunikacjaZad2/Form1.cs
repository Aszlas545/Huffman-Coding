using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using Telekomunikacja1;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace TelekomunikacjaZad2
{
    public partial class Form1 : Form   //CodeBehind :)
    {
        FileMenager fileMenager = new FileMenager();
        Huffman huffman = new Huffman();
        FileEncoder fileEncoder = new FileEncoder();
        FileReciever fileReciever = new FileReciever();
        FileSender fileSender = new FileSender();
        HuffmanNode tree = null;
        TreeSerializer serializer = new TreeSerializer();
        string bitCode = String.Empty;
        string text = String.Empty;
        string treeDictionary = String.Empty;

        public Form1()
        {
            InitializeComponent();
            Port2.Text = Convert.ToString(FreeTcpPort());   //Wyœwietlenie wolnego portu na urz¹dzeniu
            IPAddr2.Text = GetLocalIPAddress();             //Wyœwietlenie lokalnego adresu ip
        }

        private void ReadButton_Click(object sender, EventArgs e)   //Wybór pliku w oknie dialogowym
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  

            openFileDialog1.InitialDirectory = "D:\\Telekomunkacja\\TelekomunikacjaZad2\\TelekomunikacjaZad2\\TelekomunikacjaZad2\\bin\\Debug\\net6.0-windows";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                text = fileMenager.readText(selectedFileName);

                StringText.Text = text;                     //Ustawienie waidomoœci z odczytanego textu
            }
        }

        private void CodeButton_Click(object sender, EventArgs e)       //zakodowanie Wiadomoœci na 0 i 1 oraz stworzenie drzewa huffmana i wyœwietlenie s³ownika kodowego
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

        private void SendButton_Click(object sender, EventArgs e)       //Wys³anie pliku pod warunkiem ¿e odbiorca oczekuje na wiadomoœc oraz podano port i ip
        {
            byte[] send = fileEncoder.HuffmanEncoder(bitCode);
            Console.WriteLine("sums: " + string.Join(" ", send));
            if (text != String.Empty && IPAddr1.Text != "ip" && Port1.Text != "port")
            {
                string response = fileSender.sendMessage(IPAddr1.Text, Convert.ToInt32(Port1.Text), send);
                ErrorComms.Text = response;
            }
        }

        private void RecieveButtonClick(object sender, EventArgs e)     //Oczekiwanie na wiadomoœæ (proram siê zacina)
        {
            bitCode = fileReciever.recieveMessage(Convert.ToInt32(Port2.Text));
            StringText.Text = String.Empty;
            BitText.Text = bitCode;
        }

        private void DecodeButton_Click(object sender, EventArgs e)     //Odkodowanie pliku na podstawie kodu 0 i 1 oraz drzewa binarnego
        {
            if (bitCode != String.Empty && tree != null)
            {
                text = fileEncoder.HuffmanDecoder(bitCode, tree);
                StringText.Text = text;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)       //Zapis odkodowanego pliku w okdnie dialogowym
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

        private void RecieveTreeButton_Click(object sender, EventArgs e)    //Odbiór drzewa kodowego (plik siê zacina)
        {
            tree = fileReciever.recieveTree(Convert.ToInt32(Port2.Text));
            treeDictionary = huffman.generateDictionary2(tree);
            DicionaryText.Text = treeDictionary;
        }
        
        private void SendTreeButton_Click(object sender, EventArgs e)       //Nadanie drzewa kodowego pod warunkiem, ¿e odbiorca nas³uchuje
         {
            if (tree != null)
            {
                serializer.serialize(tree);
                string SignString = serializer.Text;
                string FrequenciesStirng = serializer.Frequencies;

                string msg = SignString + "*" + FrequenciesStirng;
                Console.WriteLine(msg);
                byte[] bytes = Encoding.ASCII.GetBytes(msg);
                if (treeDictionary != String.Empty && IPAddr1.Text != "ip" && Port1.Text != "port")
                {
                    string response = fileSender.sendMessage(IPAddr1.Text, Convert.ToInt32(Port1.Text), bytes);
                    ErrorComms.Text = response;
                }
            }
        }

        private static string GetLocalIPAddress()   //Funkcja uzyskuj¹ca lokalny adress ip
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static int FreeTcpPort()        //Funkcja uzyskuj¹ca jakiœ wolny port
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
    }
}