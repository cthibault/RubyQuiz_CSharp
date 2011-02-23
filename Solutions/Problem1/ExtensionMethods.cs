using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solutions.Problem1
{
    public static class ExtensionMethods
    {
        private const int ConversionDelta = 'A' - 1;
        public static IEnumerable<int> ConvertToNumbersList(this string message)
        {
            List<int> numbers = new List<int>();
            foreach (char character in message.ToCharArray().Where(c => !Char.IsWhiteSpace(c)))
                numbers.Add(character.ConvertToNumber());
            return numbers;
        }
        public static string ConvertToLettersList(this IEnumerable<int> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (int number in list)
                builder.Append(number.ConvertToLetter());
            return builder.ToString();
        }

        public static int ConvertToNumber(this char character)
        {
            return (character - ConversionDelta);
        }
        public static char ConvertToLetter(this CardValue card)
        {
            if ((int)card > 26)
                return Convert.ToChar(((int)card - 26) + ConversionDelta);
            return Convert.ToChar((int)card + ConversionDelta);
        }
        public static char ConvertToLetter(this int number)
        {
            return Convert.ToChar(number + ConversionDelta);
        }

        public static string RemovePattern(this string input, string pattern)
        {
            //Regex invalidCharacters = new Regex("[^A-Z]*");
            Regex invalidCharacters = new Regex(pattern);
            return invalidCharacters.Replace(input, string.Empty);
        }
        public static string FillRight(this string input, int modValue, char padding)
        {
            int delta = 0;
            if (input.Length % modValue > 0)
                delta = 5 - (input.Length % modValue);
            return input.PadRight(input.Length + delta, padding);
        }
        public static string GroupsOf(this string input, int groupLength, string separator)
        {
            for (int i = input.Length - groupLength; i > 0; i -= groupLength)
                input = input.Insert(i, separator);
            return input;
        }
    }
}
