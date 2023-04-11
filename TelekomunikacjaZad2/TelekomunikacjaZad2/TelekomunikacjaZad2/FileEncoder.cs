using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomunikacjaZad2;

namespace Telekomunikacja1
{
    class FileEncoder       //klasa pomocnicza która konwetuje typy danych (string, bajt, bitArray, itd.) oraz zakodowywuje i odkodowywuje nasz plik
    {

        private bool[] getBitsFromBytes(byte[] bytes)   //Funkcja zamieniącja bajt na 8 bitów
        {
            bool[] bits = new bool[bytes.Length*8];
            for (int i = 0; i < bytes.Length; i++)
            {
                bool[] BoolArray = new bool[8];
                for (int j = 0; j < 8; j++)
                    BoolArray[j] = (bytes[i] & (1 << j)) != 0;  //przesunięcie bitowe zmieniajće boole w tablicy zgodnie z bitami w bajcie
                Array.Reverse(BoolArray);                       //Zmiania kolejności bitów aby zgadzał się z zapisem little endian w widnowsie
                for (int j = 0; j < 8; j++)
                    bits[(i*8)+j] = BoolArray[j];
            }
            return bits;
        }

        public string getStringFromBytes(byte[] bytes)  //Funkcja towrząca string 0 i 1 na podstawie bajtu
        {
            string retStr = "";
            bool[] bits = getBitsFromBytes(bytes);
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == true)
                {
                    retStr += '1';
                }
                else
                {
                    retStr += '0';
                }
            }
            return retStr;
        }

        private byte ConvertBoolArrayToByte(bool[] source)  //odwrotność pierwszej funkcja zamienia bool array na bajt
        {
            byte result = 0;
            int index = 8 - source.Length;

            foreach (bool b in source)
            {
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }

        private byte ConvertStringOf8ZerosAndOnesToByte(string str)     //Funckja używana do zakodowania pliku na mniejszy rozmiar tworząca tworząca bajt ze stringa z zerami i jedynkami
        {
            bool[] bools = new bool[8];

            for (int i = 0; i < 8; i++)
            {
                if (str[i] == '1')
                {
                    bools[i] = true;
                }
                else
                {
                    bools[i] = false;
                }
            }
            return ConvertBoolArrayToByte(bools);
        }


        public byte[] HuffmanEncoder(string str)        //Funkcja kodująca wiadomość kodem huffmana
        {
            var neededZeros = 0;                        //obliczenie ile zer dopisać aby wiadomość była podzielna przez 8
            if (str.Length % 8 != 0)
            {
                neededZeros = 8 - str.Length % 8;
            }

            if (neededZeros > 0)
                str = string.Concat(str, new string('0', neededZeros)); //dołacznie zer aby osiągnąć podzielność przez 8

            byte[] retBytes = new byte[str.Length / 8];

            string temp = "";
            for (int i = 0; i < str.Length; i += 8)
            {
                for (int j = 0; j < 8; j++)
                {
                    temp += str[i+j];
                }
                retBytes[i / 8] = ConvertStringOf8ZerosAndOnesToByte(temp); //konwerstja stirnga z ośmioma 0 i jedynkami na bajt i dodanie go do tablicy
                temp = "";
            }

            return retBytes;
        }

        public string HuffmanDecoder(string bits, HuffmanNode tree)         //Funkcja na bazie drzewa binarnego odkodowująca wiadomość złożoną z zer i jedynek.
        {
            string str = "";
            for (int i = 0;i < bits.Length; i++)
            {
                HuffmanNode root = tree;
                int j = 0;
                while (root.Sign == '$')                                    //jeśli $ (u nas node bez znaku) to schodzi w lewo jeśli 0 lub w prawo jeśli 1
                {
                    if (i + j > bits.Length-1)
                    {
                        return str;
                    }
                    if (bits[i+j] == '1')
                    {
                        root = root.Right;
                    }
                    else
                    {
                        root = root.Left;
                    }
                    j++;
                }
                i += j-1;
                str += root.Sign;                                           //dopisanie do stringa znaku znalezionego w drzewie binarnym
            }
            return str;
        }
    }
}
