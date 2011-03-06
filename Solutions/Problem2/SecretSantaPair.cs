using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Problem2
{
    public class SecretSantaPair
    {
        #region Properties
        public Person Giver { get; set; }
        public Person Receiver { get; set; }

        public bool IsValid
        {
            get { return WouldBeValid(Giver, Receiver); }
        }
        #endregion Properties

        #region Constructors
        public SecretSantaPair(Person giver, Person receiver)
        {
            Giver = giver;
            Receiver = receiver;
        }
        #endregion Constructors

        #region Static Methods
        public static bool WouldBeValid(Person giver, Person receiver)
        {
            //Same Person?
            if (giver.Equals(receiver)) return false;

            //Same Family?
            if (giver.LastName.Equals(receiver.LastName)) return false;

            return true;
        }
        #endregion Static Methods

        #region Methods
        public override string ToString()
        {
            return string.Format("{0} -> {1}", Giver.FullName, Receiver.ToString());
        }
        #endregion Methods
    }
}
