using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Solutions.Problem2;

namespace Tests.Problem2
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void Clone_DeepCopy()
        {
            List<Person> list1 = new List<Person>() 
            {
                new Person("Curtis Thibault", "Email"),
                new Person("Kara Thibault", "Email")
            };
            List<Person> list2 = list1.Clone().ToList();

            Assert.AreNotSame(list2, list1);
        }

        [Test]
        public void CreateSecretSantaPairs_SameLength()
        {
            List<Person> list1 = new List<Person>() 
            {
                new Person("Curtis Thibault", "Email"),
                new Person("Kara Thibault", "Email"),
                new Person("Jake Gamble", "Email"),
                new Person("Jessica Gamble", "Email")
            };
            var pairs = list1.CreatePairs();

            Assert.AreEqual(list1.Count(), pairs.Count());
        }
        [Test]
        public void CreateSecretSantaPairs_NoDuplicateGivers()
        {
            List<Person> list1 = new List<Person>() 
            {
                new Person("Curtis Thibault", "Email"),
                new Person("Kara Thibault", "Email"),
                new Person("Jake Gamble", "Email"),
                new Person("Jessica Gamble", "Email")
            };
            var pairs = list1.CreatePairs();
            var givers = pairs.ToList().Select(p => p.Giver);

            Assert.AreEqual(list1.Distinct().Count(), givers.Distinct().Count());
        }
        [Test]
        public void CreateSecretSantaPairs_NoDuplicateReceivers()
        {
            List<Person> list1 = new List<Person>() 
            {
                new Person("Curtis Thibault", "Email"),
                new Person("Kara Thibault", "Email"),
                new Person("Jake Gamble", "Email"),
                new Person("Jessica Gamble", "Email")
            };
            var pairs = list1.CreatePairs();
            var receivers = pairs.Select(p => p);

            Assert.AreEqual(list1.Distinct().Count(), receivers.Distinct().Count());
        }
    }
}
