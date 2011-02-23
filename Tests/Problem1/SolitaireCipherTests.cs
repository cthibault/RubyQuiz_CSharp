using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Solutions.Problem1;

namespace Tests.Problem1
{
    [TestFixture]
    public class SolitaireCipherTests
    {
        [Test]
        public void GenerateKeystream_OneLetter_UnkeyedDeck()
        {
            string value = SolitaireCipher.GenerateKeystream(new Deck(true), 1);
            Assert.AreEqual("D", value);
        }
        [Test]
        public void GenerateKeystream_TenLetters_UnkeyedDeck()
        {
            string value = SolitaireCipher.GenerateKeystream(new Deck(true), 10);
            Assert.AreEqual("DWJXHYRFDG", value);
        }

        [Test]
        public void Encode()
        {
            string message = "Code in Ruby, live longer!";
            string value = SolitaireCipher.Encode(message, new Deck(true));

            Assert.AreEqual("GLNCQ MJAFF FVOMB JIYCB", value);
        }
        [Test]
        public void Decode()
        {
            string message = "GLNCQ MJAFF FVOMB JIYCB";
            string value = SolitaireCipher.Decode(message, new Deck(true));

            Assert.AreEqual("CODEI NRUBY LIVEL ONGER", value);
        }
    }
}
