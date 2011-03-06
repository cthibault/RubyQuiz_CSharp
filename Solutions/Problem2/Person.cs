using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Problem2
{
    public class Person
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        #endregion Properties

        #region Constructors
        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public Person(string fullName, string email)
        {
            string[] names = fullName.Split(' ');

            FirstName = (names.Length > 0) ? names[0] : string.Empty;
            LastName = (names.Length > 1) ? names[1] : string.Empty;
            Email = email;
        }
        #endregion Constructors

        #region Public Methods
        public Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", FullName, Email);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Person)) return false;

            return Equals(obj as Person);
        }
        public bool Equals(Person otherPerson)
        {
            if (otherPerson == null) return false;

            if (!FirstName.Equals(otherPerson.FirstName)) return false;
            if (!LastName.Equals(otherPerson.LastName)) return false;

            return true;
        }
        #endregion Public Methods
    }
}
