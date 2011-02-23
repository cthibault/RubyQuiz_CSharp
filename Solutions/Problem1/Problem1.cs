using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Problem1
{
    public class Problem1
    {
        public static void Run(string message, bool encode)
        {
            Deck deck = new Deck(true);
            string output = encode ? SolitaireCipher.Encode(message, deck) : SolitaireCipher.Decode(message, deck);

            Console.WriteLine(string.Format("Original Message: {0}", message));
            Console.WriteLine(string.Format("Output: {0}", output));
            Console.WriteLine();
        }
    }
}
