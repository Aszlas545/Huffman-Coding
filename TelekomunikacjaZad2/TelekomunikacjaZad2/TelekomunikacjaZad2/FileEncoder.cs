using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikacja1
{
    class fileEncoder
    {
        List<bool[]> inputList = new List<bool[]>();
        List<bool[]> outputList = new List<bool[]>();

        private void getBitsFromBytes(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bool[] BoolArray = new bool[8];
                for (int j = 0; j < 8; j++)
                    BoolArray[j] = (bytes[i] & (1 << j)) != 0;
                Array.Reverse(BoolArray);
                inputList.Add(BoolArray);
            }
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
    }
}
