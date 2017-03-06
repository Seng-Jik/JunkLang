using System;
using System.Collections.Generic;
using System.Text;

namespace JunkLang
{
    public static class RomeNumber
    {
        public static byte Rome2Byte(string rome)
        {
            List<byte> numbers = new List<byte>();

            numbers.Add(0);
            foreach (var i in rome)
            {
                if (i == 'O') numbers.Add(0);
                else if (i == 'I') numbers.Add(1);
                else if (i == 'V') numbers.Add(5);
                else if (i == 'X') numbers.Add(10);
                else if (i == 'L') numbers.Add(50);
                else if (i == 'C') numbers.Add(100);
                else throw new Exception("Invalid number:" + rome);
            }
            numbers.Add(0);
            numbers.Add(0);

            byte number = 0;

            for (int i = 1; i < numbers.Count - 1; i++)
            {
                if (numbers[i] >= numbers[i + 1])
                    number += numbers[i];

                else
                    number -= numbers[i];
            }
            return number;
        }

    }
}
