using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkLang.Tests
{
    [TestClass()]
    public class CSharpCompilerTests
    {
        [TestMethod()]
        public void CompileCodesTest()
        {
            CSharpCompiler.CompileCodes("using System;\r\nnamespace CodeDomSample\r\n{\r\nclass Program\r\n{\r\nstatic void Main(string[] args)\r\n{\r\nConsole.WriteLine(\"Hello World!\");\r\nConsole.ReadLine();\r\n}\r\n}\r\n}", "D:\\C# Code\\CompileTest.exe");
            //Assert.Fail();
        }
    }
}