using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomunikacjaZad2;

namespace Telekomunikacja1
{
    class FileEncoder
    {

        private bool[] getBitsFromBytes(byte[] bytes)
        {
            bool[] bits = new bool[bytes.Length*8];
            for (int i = 0; i < bytes.Length; i++)
            {
                bool[] BoolArray = new bool[8];
                for (int j = 0; j < 8; j++)
                    BoolArray[j] = (bytes[i] & (1 << j)) != 0;
                Array.Reverse(BoolArray);
                for (int j = 0; j < 8; j++)
                    bits[(i*8)+j] = BoolArray[j];
            }
            return bits;
        }

        public string getStringFromBytes(byte[] bytes)
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

        private byte ConvertBoolArrayToByte(bool[] source)
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

        private byte ConvertStringOf8ZerosAndOnesToByte(string str)
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


        public byte[] HuffmanEncoder(string str)
        {
            var neededZeros = 0;
            if (str.Length % 8 != 0)
            {
                neededZeros = 8 - str.Length % 8;
            }

            if (neededZeros > 0)
                str = string.Concat(str, new string('0', neededZeros));

            byte[] retBytes = new byte[str.Length / 8];

            string temp = "";
            for (int i = 0; i < str.Length; i += 8)
            {
                for (int j = 0; j < 8; j++)
                {
                    temp += str[i+j];
                }
                retBytes[i / 8] = ConvertStringOf8ZerosAndOnesToByte(temp);
                temp = "";
            }

            return retBytes;
        }

        public string HuffmanDecoder(string bits, HuffmanNode tree)
        {
            string str = "";
            for (int i = 0;i < bits.Length; i++)
            {
                HuffmanNode root = tree;
                int j = 0;
                while (root.Sign == '$')
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
                str += root.Sign;
            }
            return str;
        }
    }
}
