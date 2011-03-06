using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1
            //Problem1.Problem1.Run("CLEPK HHNIY CFPWH FDFEH", false);
            //Problem1.Problem1.Run("ABVAW LWZSY OORYK DUPVH", false);
            //Console.Read();
            #endregion Problem 1

            #region Problem 2
            Problem2.Person p1 = new Problem2.Person("Curtis Thibault", "test");

            List<Problem2.Person> list = new List<Problem2.Person>()
            {
                new Problem2.Person("Curtis Thibault", "email"),
                new Problem2.Person("Kara Thibault", "email"),
                new Problem2.Person("Kelly Shore", "email"),
                new Problem2.Person("Michele Shore", "email"),
                new Problem2.Person("Jake Gamble", "email"),
                new Problem2.Person("Jessica Gamble", "email"),
                new Problem2.Person("Ryan Shea", "email"),
                new Problem2.Person("Sharon Shea", "email")
            };

            for (int i = 0; i < 5; i++)
            {
                Problem2.SecretSantaPairer ssp = new Problem2.SecretSantaPairer(list);
                Console.Write(ssp.ToString());
                Console.Read();
                Console.Clear();
            }
            #endregion Problem 2
        }
    }
}
