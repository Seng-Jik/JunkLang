using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace JunkLang
{
    public class Precompiler
    {
        private System.IO.StringReader m_source;

        public void SetSourceCode(string s)
        {
            m_source = new StringReader(s);
        }

        public ArrayList Precompile()
        {
            ArrayList codes = new ArrayList();

            while (m_source.Peek() != -1)
            {
                string line = m_source.ReadLine();
                line += ',';

                var comment = line.IndexOf(',');

                line = line.Substring(0, comment);
                line = line.Trim(" \t\r\n".ToCharArray());

                if (line == null || line == "") continue;

                codes.Add(line);
            }

            return codes;
        }
    }
}
