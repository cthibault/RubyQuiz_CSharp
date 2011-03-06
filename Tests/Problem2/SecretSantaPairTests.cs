using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Solutions.Problem2;

namespace Tests.Problem2
{
    [TestFixture]
    public class SecretSantaPairTests
    {
        [Test]
        public void Giver()
        {
            Person person1 = new Person("One Last", "Email");
            Person person2 = new Person("Two Last", "Email");
            SecretSantaPair pair = new SecretSantaPair(person1, person2);

            Assert.AreEqual(person1, pair.Giver);
        }
        [Test]
        public void Receiver()
        {
            Person person1 = new Person("One Last", "Email");
            Person person2 = new Person("Two Last", "Email");
            SecretSantaPair pair = new SecretSantaPair(person1, person2);

            Assert.AreEqual(person2, pair.Receiver);
        }

        [Test]
        public void InvalidPair_SamePerson()
        {
            Person person1 = new Person("First Person", "Email");
            Person person2 = new Person("First Person", "Email");
            SecretSantaPair pair = new SecretSantaPair(person1, person2);

            Assert.False(pair.IsValid);
        }
        [Test]
        public void InvalidPair_SameFamily()
        {
            Person person1 = new Person("First Person", "Email");
            Person person2 = new Person("Second Person", "Email");
            SecretSantaPair pair = new SecretSantaPair(person1, person2);

            Assert.False(pair.IsValid);
        }
        [Test]
        public void ValidPair()
        {
            Person person1 = new Person("Curtis Thibault", "Email");
            Person person2 = new Person("Jake Gamble", "Email");
            SecretSantaPair pair = new SecretSantaPair(person1, person2);

            Assert.True(pair.IsValid);
        }

        [Test]
        public void WouldBe_ValidPair()
        {
            Person person1 = new Person("Curtis Thibault", "Email");
            Person person2 = new Person("Jake Gamble", "Email");

            Assert.True(SecretSantaPair.WouldBeValid(person1, person2));
        }
    }
}
