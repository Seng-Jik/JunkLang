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
            byte[] times = new byte[255];
            if (numbers.Count == 0) throw new Exception("Invalid number");
            foreach (var i in rome)
            {
                if (i == 'O') numbers.Add(0);
                else if (i == 'I') numbers.Add(1);
                else if (i == 'V') numbers.Add(5);
                else if (i == 'X') numbers.Add(10);
                else if (i == 'L') numbers.Add(50);
                else if (i == 'C') numbers.Add(100);
                else if (i == 'D') throw new Exception("Out of range");
                else if (i == 'M') throw new Exception("Out of range");
                else throw new Exception("Invalid number:" + rome);
                times[i]++;
            }
            if (times['0'] > 1) throw new Exception("Invalid number");
            if (times['0'] > 0 && (times['I'] > 0 || times['V'] > 0 || times['X'] > 0 || times['L'] > 0 || times['C'] > 0)) throw new Exception("Invalid number");
            if (times['V'] > 1 || times['L'] > 1 || times['I'] > 3 || times['X'] > 3 || times['C'] > 3) throw new Exception("Rule error");
            byte before = 0;
            byte number = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > before)
                {
                    if ((byte)(int)(numbers[i] - before) < 0) throw new Exception("Error");
                    before = (byte)(int)(numbers[i] - before);
                    number = before;
                }
                else if (numbers[i] <= before)
                {
                    before += numbers[i];
                    number = before;
                }
            }
            return number;
        }

    }
}
