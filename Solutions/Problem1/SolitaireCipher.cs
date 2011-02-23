using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solutions.Problem1
{
    public class SolitaireCipher
    {
        #region Constants
        private static readonly string InvalidCharacters = "[^A-Z]*";

        private static readonly Func<char, bool> NonWhitespaceCharacter = character => !Char.IsWhiteSpace(character);
        private static readonly Func<int, int, int> MergeEncode = (first, second) => first + second - ((first + second > 26) ? 26 : 0);
        private static readonly Func<int, int, int> MergeDecode = (first, second) => first + ((first <= second) ? 26 : 0) - second;
        #endregion Constants

        #region Constructor
        private SolitaireCipher() {}
        #endregion Constructor

        #region Methods
        public static string Encode(string message, Deck deck)
        {
            string newMessage = Sanitize(message);
            string keystream = GenerateKeystream(deck, newMessage.Length);

            IEnumerable<int> cipherNumbers = newMessage.ConvertToNumbersList().Zip(keystream.ConvertToNumbersList(), MergeEncode);
            return cipherNumbers.ConvertToLettersList().GroupsOf(5, " ");
        }
        public static string Decode(string message, Deck deck)
        {
            string newMessage = Sanitize(message);
            string keystream = GenerateKeystream(deck, newMessage.Length);

            IEnumerable<int> cipherNumbers = newMessage.ConvertToNumbersList().Zip(keystream.ConvertToNumbersList(), MergeDecode);
            string v = cipherNumbers.ConvertToLettersList().GroupsOf(5, " ");

            return v;
        }
        public static string GenerateKeystream(Deck deck, int length)
        {
            StringBuilder keystream = new StringBuilder();
            while (keystream.Length < length)
            {
                deck.MoveCardDown(CardValue.JokerA, 1);
                deck.MoveCardDown(CardValue.JokerB, 2);
                deck.TripleCut(CardValue.JokerA, CardValue.JokerB);
                deck.CountCut();

                CardValue outputCard = deck.Cards.Take((int)deck.Cards.First() + 1).Last();

                if (!Deck.IsJoker(outputCard))
                    keystream.Append(outputCard.ConvertToLetter());
            }

            return keystream.ToString();
        }

        private static string Sanitize(string message)
        {
            return message.ToUpper().RemovePattern(InvalidCharacters).FillRight(5, 'X'); //.GroupsOf(5, " ");
        }
        #endregion Methods
    }
}
