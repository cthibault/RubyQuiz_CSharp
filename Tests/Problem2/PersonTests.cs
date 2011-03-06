using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Solutions.Problem2;

namespace Tests.Problem2
{
    [TestFixture]
    public class PersonTests
    {
        private const string FIRSTNAME = "Curtis";
        private const string LASTNAME = "Thibault";
        private const string FULL_NAME = "Curtis Thibault";
        private const string EMAIL = "curtis.thibault@gmail.com";

        [Test]
        public void FirstName_SeparateFirstAndLastNames()
        {
            Person person = new Person(FIRSTNAME, LASTNAME, EMAIL);

            Assert.AreEqual(FIRSTNAME, person.FirstName);
        }
        [Test]
        public void LastName_SeparateFirstAndLastNames()
        {
            Person person = new Person(FIRSTNAME, LASTNAME, EMAIL);

            Assert.AreEqual(LASTNAME, person.LastName);
        }
        [Test]
        public void Email_SeparateFirstAndLastNames()
        {
            Person person = new Person(FIRSTNAME, LASTNAME, EMAIL);

            Assert.AreEqual(EMAIL, person.Email);
        }
        [Test]
        public void FullName_SeparateFirstAndLastNames()
        {
            Person person = new Person(FIRSTNAME, LASTNAME, EMAIL);

            Assert.AreEqual(FULL_NAME, person.FullName);
        }

        [Test]
        public void FirstName_CombinedFirstAndLastNames()
        {
            Person person = new Person(FULL_NAME, EMAIL);

            Assert.AreEqual(FIRSTNAME, person.FirstName);
        }
        [Test]
        public void LastName_CombinedFirstAndLastNames()
        {
            Person person = new Person(FULL_NAME, EMAIL);

            Assert.AreEqual(LASTNAME, person.LastName);
        }
        [Test]
        public void Email_CombinedFirstAndLastNames()
        {
            Person person = new Person(FULL_NAME, EMAIL);

            Assert.AreEqual(EMAIL, person.Email);
        }
        [Test]
        public void FullName_CombinedFirstAndLastNames()
        {
            Person person = new Person(FULL_NAME, EMAIL);

            Assert.AreEqual(FULL_NAME, person.FullName);
        }

        [Test]
        public void Clone_Equal()
        {
            Person person1 = new Person(FULL_NAME, EMAIL);
            Person person2 = person1.Clone();

            Assert.AreEqual(person1, person2);
        }
        [Test]
        public void Clone_NotSameObject()
        {
            Person person1 = new Person(FULL_NAME, EMAIL);
            Person person2 = person1.Clone();

            Assert.AreNotSame(person1, person2);
        }
    }
}
