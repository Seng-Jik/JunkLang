using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JunkLang
{
    public class CompilePipe
    {
        private string mOutput;
        private string mCode;

        public string Output
        {
            get
            {
                return mOutput;
            }

            set
            {
                mOutput = value;
            }
        }

        public string Code
        {
            get
            {
                return mCode;
            }

            set
            {
                mCode = value;
            }
        }

        public void Compile()
        {
            var precompiled = Precompiler.Precompile(new StringReader(mCode));
            var lexed = Lexer.GetTokens(precompiled);
            var parsed = Parser.Parse(lexed);
            var cSharp = CSharpCodeGen.GenCode(parsed);
            CSharpCompiler.CompileCodes(cSharp, mOutput);
        }
    }
}
