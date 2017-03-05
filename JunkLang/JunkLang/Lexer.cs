using System;
using System.Collections.Generic;
using System.Text;

namespace JunkLang
{
    public static class Lexer
    {
        public struct Token
        {
            enum Type{
                Number,
                Command
            }
            Type type;
            string word;
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

        static List<Token> GetTokens(string code)
        {
            //TODO：GetToken
            return new List<Token>();
        }
    }
}
