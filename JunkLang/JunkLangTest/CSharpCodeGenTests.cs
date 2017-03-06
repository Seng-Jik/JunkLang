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
    public class CSharpCodeGenTests
    {
        public static string GenCodeFromJunk(string path)
        {
            var sents = ParserTests.ParseFile(path);
            return CSharpCodeGen.GenCode(sents);
        }

        private static void PrintCode(string path)
        {
            Console.Write(GenCodeFromJunk(path));
        }

        [TestMethod()]
        public void GenHelloWorldTest()
        {
            PrintCode("HelloWorld.junk");
        }

        [TestMethod()]
        public void GenCircleTest()
        {
            PrintCode("Circle.junk");
        }
    }
}