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
                c == 'O' ||
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

        static private void PushNumberToken(ref Token token,IList<Token> tokens)
        {
            if (token.word != "" && token.word != null) tokens.Add(token);
            token.word = "";
        }

        static public IList<Token> GetTokens(string code)
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
                    PushNumberToken(ref numberToken, tokens);
                    Token tkn = new Token();
                    tkn.type = Token.Type.Command;
                    tkn.word += ch;
                    tokens.Add(tkn);
                }
                else if (IsNumber(ch))
                {
                    numberToken.word += ch;
                }
                else
                {
                    throw new Exception("Unknown Char:" + ch);
                }
            }
            PushNumberToken(ref numberToken , tokens);

            return tokens;
        }
    }
}
