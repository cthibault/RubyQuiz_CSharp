using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Problem2
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Person> Clone(this IEnumerable<Person> people)
        {
            List<Person> list = new List<Person>();
            foreach (Person person in people)
                list.Add(person.Clone());
            return list;
        }

        public static IEnumerable<SecretSantaPair> CreatePairs(this IEnumerable<Person> people)
        {
            Random random = new Random();
            int index = -1;

            List<Person> secondList = people.Clone().ToList();
            List<SecretSantaPair> list = new List<SecretSantaPair>();
            foreach (Person person in people)
            {
                index = random.Next(0, secondList.Count);
                list.Add(new SecretSantaPair(person, secondList[index]));
                secondList.RemoveAt(index);
            }     
                                                                                                               
            return list;
        }
    }
}
