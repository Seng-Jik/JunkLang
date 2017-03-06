using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkLangTest
{
    [TestClass()]
    public class RomeNumberTests
    {
        [TestMethod()]
        public void Rome2ByteTest()
        {
            IDictionary < byte,string> dics = new Dictionary<byte, string>();
            dics[0] = "O";
            dics[1] = "I";
            dics[2] = "II";
            dics[3] = "III";
            dics[4] = "IV";
            dics[5] = "V";
            dics[10] = "X";
            dics[49] = "IL";
            dics[51] = "LI";
            dics[128] = "CXXVIII";
            dics[255] = "CCLV";
            
            foreach(var i in dics)
            {
                Assert.AreEqual(RomeNumber.Rome2Byte(i.Value), i.Key);
            }
        }
    }
}