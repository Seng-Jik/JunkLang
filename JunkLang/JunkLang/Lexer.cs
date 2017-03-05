using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JunkLang
{
    public static class Lexer
    {
        public struct Token
        {
            public enum Type{
                Number,
                Command
            }
            public Type type;
            public string word;
        }

        private static bool IsNumber(char c)
        {
            return
                c == 'I' ||
                c == 'V' ||
                c == 'X' ||
                c == 'L' ||
                c == 'C';
        }

        private static bool IsCommand(char c)
        {
            return
                c == ';' ||
                c == '#' ||
                c == '-' ||
                c == '+' ||
                c == '/' ||
                c == '&' ||
                c == '_' ||
                c == '%' ||
                c == '*' ||
                c == '~' ||
                c == ']' ||
                c == '[' ||
                c == '0' ||
                c == '!' ||
                c == '|' ||
                c == '?' ||
                c == '^' ||
                c == 'v' ||
                c == '<' ||
                c == '>';
        }

        static private void PushNumberToken(Token token,IList<Token> tokens)
        {
            if (token.word != "" && token.word != null) tokens.Add(token);
            token.word = "";
        }

        static IList<Token> GetTokens(string code)
        {
            
            var tokens = new List<Token>();
            var codeReader = new StringReader(code);

            Token numberToken = new Token();
            numberToken.type = Token.Type.Number;

            while(codeReader.Peek() != -1)
            {
                char ch = (char)codeReader.Read();

                if (IsCommand(ch))
                {
                    PushNumberToken(numberToken, tokens);
                }
                else if (IsNumber(ch))
                {
                    numberToken.word += ch;
                }
            }
            PushNumberToken(numberToken , tokens);

            return tokens;
        }
    }
}
