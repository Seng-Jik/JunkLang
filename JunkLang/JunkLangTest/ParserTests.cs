using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkLangTest
{
    [TestClass()]
    public class ParserTests
    {
        public static IList<Parser.Sentence> ParseFile(string path)
        {
            var lexed = LexerTest.GetLexingResult(path);
            return Parser.Parse(lexed);
        }

        private static void PrintSentences(string path)
        {
            var sents = ParseFile(path);

            foreach(var i in sents)
            {
                string info = "";
                info += i.command;
                info += '\t';
                info += i.argument;
                Console.WriteLine(info);
            }
        }

        [TestMethod()]
        public void ParseHelloWorldTest()
        {
            PrintSentences("HelloWorld.junk");
        }

        [TestMethod()]
        public void ParseCircleTest()
        {
            PrintSentences("Circle.junk");
        }
    }
}