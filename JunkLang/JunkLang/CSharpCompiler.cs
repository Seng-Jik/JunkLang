using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
namespace JunkLang
{
    public static class CSharpCompiler
    {
        private static CompilerResults CompileCode(CodeDomProvider provider, string Codes, string filepath)
        {
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters cp = new CompilerParameters(new string[] { "System.dll" }, filepath, false);
            cp.GenerateExecutable = true;
            CompilerResults cr = compiler.CompileAssemblyFromSource(cp, Codes);
            return cr;
        }
        public static bool CompileCodes(string Codes, string path)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerResults cr = CompileCode(provider, Codes, path);
            if (cr.Errors.Count > 0)
            {
                throw new Exception("Compile Filed");
            }
            return true;
        }
    }
}
