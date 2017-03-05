using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace JunkLangTest
{
    [TestClass]
    public class PrecompilerTest
    {
        private void PrecompileAndCreateResult(string testCodeFilePath)
        {
            JunkLang.Precompiler precomp = new JunkLang.Precompiler();

            var stream = File.OpenText("..\\..\\" + testCodeFilePath);
            precomp.SetSourceCode(stream.ReadToEnd());

            foreach(var i in precomp.Precompile())
              Console.WriteLine("BEGIN["+i+"]END");
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
