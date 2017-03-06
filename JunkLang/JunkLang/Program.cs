using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JunkLang
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("JunkLang sourceCode.junk dst.exe");
            }
            else
            {
                CompilePipe pipe = new CompilePipe();
                pipe.Code = File.ReadAllText(args[0]);
                pipe.Output = args[1];
                try
                {
                    pipe.Compile();
                }
                catch(Exception e)
                {
                    Console.WriteLine("ERROR:" + e.Message);
                }
            }
        }
    }
}
