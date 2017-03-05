using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using JunkLang;

namespace JunkLangTest
{
    [TestClass]
    public class PrecompilerTest
    {
        public static string Precompile(string testCodeFilePath)
        {
            return Precompiler.Precompile(new StringReader(File.OpenText("..\\..\\" + testCodeFilePath).ReadToEnd()));
        }
        private static void PrecompileAndCreateResult(string testCodeFilePath)
        {
             Console.WriteLine(Precompile(testCodeFilePath));
        }

        [TestMethod]
        public void TestHelloWorld()
        {
            PrecompileAndCreateResult("HelloWorld.junk");
        }

        [TestMethod]
        public void TestCircle()
        {
            PrecompileAndCreateResult("Circle.junk");
        }
    }
}
