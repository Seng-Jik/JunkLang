using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace JunkLang
{
    public static class Precompiler
    {

        public static string Precompile(System.IO.StringReader source)
        {
            string codes = "";

            while (source.Peek() != -1)
            {
                string line = source.ReadLine();
                line += ',';

                var comment = line.IndexOf(',');

                line = line.Substring(0, comment);
                line = line.Trim(" \t\r\n".ToCharArray());

                if (line == null || line == "") continue;

                codes += line;
            }

            return codes;
        }
    }
}
