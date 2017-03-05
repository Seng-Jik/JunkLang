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

             Console.WriteLine(precomp.Precompile());
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
