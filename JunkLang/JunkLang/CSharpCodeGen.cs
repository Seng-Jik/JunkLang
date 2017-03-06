using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace JunkLang
{
    public static class CSharpCodeGen
    {
        private static void GenBegin(StringBuilder sb)
        {
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("");
            sb.AppendLine("namespace JunkProgram");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic class JunkMain");
            sb.AppendLine("\t{");

            //Gen Memory
            sb.AppendLine("\t\tprivate static byte [] mMemory;");
            sb.AppendLine("\t\tprivate static int mPtr;");

            //Gen Memory Resizer
            sb.AppendLine("\t\tprivate static ChangeMemory(int sizeChanged)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tbyte [] backup = mMemory;");
            sb.AppendLine("\t\t\tif(backup != null){");
            sb.AppendLine("\t\t\t\tmMemory = new byte[backup.Length + sizeChanged];");
            sb.AppendLine("\t\t\t\tArray.Copy(backup,0,mMemory,0,mMemory.Length > backup.Length ? backup.Length : mMemory.Length);");
            sb.AppendLine("\t\t\t}else");
            sb.AppendLine("\t\t\t\tmMemory = new byte[sizeChanged];");
            sb.AppendLine("\t\t}");

            sb.AppendLine("\t\tpublic static void Main()");
            sb.AppendLine("\t\t{");

            
        }

        private static void GenEnd(StringBuilder sb)
        {
            sb.AppendLine("");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
        }

        private static string GetCode(Parser.Sentence sent)
        {
            var codeDics = new Dictionary<char, string>();
            codeDics[';'] = "mMemory[mPtr] = @;";
            codeDics['#'] = "mMemory[mPtr+1] = mMemory[mPtr];";
            codeDics['-'] = "mMemory[mPtr] += @;";
            codeDics['+'] = "mMemory[mPtr] -= @;";
            codeDics['/'] = "mMemory[mPtr] *= @;";
            codeDics['&'] = "mMemory[mPtr] = Math.Pow(mMemory[mPtr],@);";
            codeDics['_'] = "mMemory[mPtr] = Math.Sqrt(mMemory[mPtr]);";
            codeDics['%'] = "mMemory[mPtr] /= @;";
            codeDics['*'] = "mMemory[mPtr] %= @;";
            codeDics['~'] = "mMemory[mPtr] = mMemory[mPtr] > 0 ? 0 : 1;";
            codeDics[']'] = "mPtr += @;";
            codeDics['['] = "mPtr -= @;";
            codeDics['0'] = "mPtr = 0;";
            codeDics['!'] = "if(mMemory[mPtr] == 0) goto LAB_@;";
            codeDics['|'] = "goto LAB_@;";
            codeDics['?'] = "LAB_@:";
            codeDics['^'] = "ChangeMemory(@);";
            codeDics['v'] = "ChangeMemory(-@);";
            codeDics['<'] = "Console.WriteLine(mMemory[mPtr].ToString());";
            codeDics['>'] = "mMemory[mPtr] = Convert.ToByte(Console.ReadLine());";
            return "\t\t\t" + codeDics[sent.command].Replace("@", sent.argument.ToString());
        }

        public static string GenCode(IList<Parser.Sentence> sents)
        {
            StringBuilder sb = new StringBuilder();
            GenBegin(sb);

            foreach(var i in sents)
            {
                sb.AppendLine(GetCode(i));
            }

            GenEnd(sb);
            return sb.ToString();
        }
    }
}
