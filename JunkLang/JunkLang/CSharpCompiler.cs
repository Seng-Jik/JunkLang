using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
namespace JunkLang
{
    public static class CSharpCompiler
    {
        private static CompilerResults CompileCode(CodeDomProvider provider, string filepath)
        {
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters cp = new CompilerParameters(new string[] { "System.dll" }, filepath.Substring(0, filepath.LastIndexOf(".") + 1) + "exe", false);
            cp.GenerateExecutable = true;
            CompilerResults cr = compiler.CompileAssemblyFromFile(cp, filepath);
            return cr;
        }
        
        public static bool CompileCodes(string Codes, string path)
        {
            StreamWriter sw = new StreamWriter(path, true);
            CodeDomProvider provider = new CSharpCodeProvider();
            string[] Lines = Codes.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in Lines)
            {
                sw.WriteLine(s);
            }
            sw.Close();
            sw.Dispose();
            CompilerResults cr = CompileCode(provider, path);
            if (cr.Errors.Count > 0)
            {
                throw new Exception("Compile Filed");
            }
            return true;
        }
    }
}
