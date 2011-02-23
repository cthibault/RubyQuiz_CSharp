using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Solutions.Problem1;
using NUnit.Framework;

namespace Tests.Problem1
{
    [TestFixture]
    public class ExtensionMethodsTests
    {
        [Test]
        public void ConvertToNumbers_LetterA()
        {
            char c = 'A';
            int value = c.ConvertToNumber();

            Assert.AreEqual(1, value);
        }
        [Test]
        public void ConvertToNumbers_LetterM()
        {
            char c = 'N';
            int value = c.ConvertToNumber();

            Assert.AreEqual(14, value);
        }
        [Test]
        public void ConvertToNumbers_LetterZ()
        {
            char c = 'Z';
            int value = c.ConvertToNumber();

            Assert.AreEqual(26, value);
        }
        [Test]
        public void ConvertToNumbersList_EntireAlphabet()
        {            
            string message = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = message.ConvertToNumbersList();
            var manualNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            
            Assert.AreEqual(manualNumbers, numbers.ToList<int>());
        }
        [Test]
        public void ConvertToNumbersList_WithSpaces()
        {
            string message = "ABCXY Z";
            var numbers = message.ConvertToNumbersList();
            var manualNumbers = new List<int>() { 1, 2, 3, 24, 25, 26 };

            Assert.AreEqual(manualNumbers, numbers.ToList<int>());
        }

        [Test]
        public void ConvertToLetter_AceOfClubs()
        {
            CardValue card = CardValue.AceOfClubs;
            char value = card.ConvertToLetter();
            
            Assert.AreEqual('A', value);
        }
        [Test]
        public void ConvertToLetter_AceOfHearts()
        {
            CardValue card = CardValue.AceOfHearts;
            char value = card.ConvertToLetter();

            Assert.AreEqual('A', value);
        }
        [Test]
        public void ConvertToLetter_AceOfDiamonds()
        {
            CardValue card = CardValue.AceOfDiamonds;
            char value = card.ConvertToLetter();
            
            Assert.AreEqual('N', value);
        }
        [Test]
        public void ConvertToLetter_AceOfSpades()
        {
            CardValue card = CardValue.AceOfSpades;
            char value = card.ConvertToLetter();

            Assert.AreEqual('N', value);
        }
        [Test]
        public void ConvertToLetter_KingOfDiamonds()
        {
            CardValue card = CardValue.KingOfDiamonds;
            char value = card.ConvertToLetter();

            Assert.AreEqual('Z', value);
        }
        [Test]
        public void ConvertToLetter_KingOfSpades()
        {
            CardValue card = CardValue.KingOfSpades;
            char value = card.ConvertToLetter();

            Assert.AreEqual('Z', value);
        }


        [Test]
        public void ConvertToLetter_Number1()
        {
            int number = 1;
            char value = number.ConvertToLetter();

            Assert.AreEqual('A', value);
        }
        [Test]
        public void ConvertToLetter_Number13()
        {
            int number = 13;
            char value = number.ConvertToLetter();

            Assert.AreEqual('M', value);
        }
        [Test]
        public void ConvertToLetter_Number26()
        {
            int number = 26;
            char value = number.ConvertToLetter();

            Assert.AreEqual('Z', value);
        }

        [Test]
        public void ConvertToLetterList_EntireAlphabet_Numbers()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 26);
            string value = numbers.ConvertToLettersList();

            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ", value);
        }
        [Test]
        public void ConvertToLetterList_EntireAlphabet_Cards()
        {
            List<char> expectedLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            List<char> letters = new List<char>();
            foreach (CardValue card in new Deck(false).Cards)
                letters.Add(card.ConvertToLetter());

            Assert.AreEqual(expectedLetters, letters);
        }

        [Test]
        public void RemoveNonAlphaCharacters()
        {
            string value = "A1-.B ,%'/C\\    D\n";
            value = value.RemovePattern("[^A-Z]*");

            Assert.AreEqual("ABCD", value);
        }

        [Test]
        public void FillRightWithX_Unnecessary()
        {
            string value = "ABCDE";
            value = value.FillRight(5, 'X');

            Assert.AreEqual("ABCDE", value);
        }
        [Test]
        public void FillRightWithX_Short()
        {
            string value = "ABC";
            value = value.FillRight(5, 'X');

            Assert.AreEqual("ABCXX", value);
        }
        [Test]
        public void FillRightWithX_Long()
        {
            string value = "ABCDEFGHIJK";
            value = value.FillRight(5, 'X');

            Assert.AreEqual("ABCDEFGHIJKXXXX", value);
        }

        [Test]
        public void GroupsOfFive_Short()
        {
            string value = "ABCDEFGHIJ";
            value = value.GroupsOf(5, " ");

            Assert.AreEqual("ABCDE FGHIJ", value);
        }
        [Test]
        public void GroupsOfFive_Long()
        {
            string value = "ABCDEFGHIJKLMNOPQRST";
            value = value.GroupsOf(5, " ");

            Assert.AreEqual("ABCDE FGHIJ KLMNO PQRST", value);
        }
    }
}
