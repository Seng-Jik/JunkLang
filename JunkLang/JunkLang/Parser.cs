using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace JunkLang
{
    public static class Parser
    {
        public struct Sentence{
            public char command;
            public byte argument;
        }

        public static IList<Sentence> Parse(IList<Lexer.Token> tokens)
        {
            const string cmdNeedArg = ";-+/&%*~][!|?^v";
            const string cmdNeedntArg = "#0<_>";

            Queue < Lexer.Token > tokenQueue = new Queue<Lexer.Token>(tokens);

            IList<Sentence> sentList = new List<Sentence>();
           
            while(tokenQueue.Count > 0)
            {
                //取指令
                var cmd = tokenQueue.Dequeue();
                Sentence sent = new Sentence();

                if (cmd.type == Lexer.Token.Type.Command)
                {
                    sent.command = cmd.word[0];

                    if (cmdNeedArg.IndexOf(sent.command) >= 0)
                    {
                        //取参数
                        var arg = tokenQueue.Dequeue();
                        if (arg.type == Lexer.Token.Type.Number)
                        {
                            sent.argument = RomeNumber.Rome2Byte(arg.word);
                        }
                        else
                            throw new Exception("The argument of " + sent.command + " must is a rome number,but it is " + cmd.word);
                    }
                    else if (cmdNeedntArg.IndexOf(sent.command) >= 0)
                    {
                        sent.argument = 0;
                    }
                    else
                        throw new Exception("Unknown command:" + sent.command);
                }
                else
                    throw new Exception("It is an unuseable word:" + cmd.word);

                sentList.Add(sent);
            }
            return sentList;
        }
    }
}
