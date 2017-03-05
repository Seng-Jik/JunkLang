using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using JunkLang;
namespace JunkLangTest
{
    [TestClass]
    class LexerTest
    {
        public static IList<JunkLang.Lexer.Token> GetLexingResult(string path)
        {
            //Precompile
            string precompiled = PrecompilerTest.Precompile(path);
            return Lexer.GetTokens(precompiled);
        }

        private static void PrintTokens(string path)
        {
            IList<JunkLang.Lexer.Token> tokens = GetLexingResult(path);
            foreach (var t in tokens)
            {
                string info = t.type == Lexer.Token.Type.Command ? "Command" : "Number";
                info += ':';
                info += t.word;
                Console.WriteLine(info);
            }
        }

        [TestMethod]
        public void TestHelloWorld()
        {
            PrintTokens("HelloWorld.junk");
        }

        [TestMethod]
        public void TestCircle()
        {
            PrintTokens("Circle.junk");
        }
    }
}
