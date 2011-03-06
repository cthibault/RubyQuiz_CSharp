using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Problem2
{
    public class SecretSantaPairer
    {
        private const string INVALID_LIST = "ERROR: The list provided could not produce a valid set.";
        public bool IsValidList
        {
            get { return !List.Any(p => !p.IsValid); }
        }
        public IEnumerable<SecretSantaPair> List { get; private set; }

        public SecretSantaPairer(List<Person> people)
        {
            int noMatchCounter = 0;
            SecretSantaPair pair2 = null;
            Person temp;
            Func<SecretSantaPair, bool> ValidFunction = null;

            List = people.CreatePairs();
            do
            {
                foreach (var pair in List.Where(p => !p.IsValid))
                {
                    if (ValidFunction == null)
                        ValidFunction = p => SecretSantaPair.WouldBeValid(pair.Giver, p.Receiver) &&
                                             SecretSantaPair.WouldBeValid(p.Giver, pair.Receiver);

                    pair2 = List.Where(p => !p.IsValid).FirstOrDefault(ValidFunction)
                         ?? List.FirstOrDefault(ValidFunction);

                    if (pair2 != null)
                    {
                        temp = pair.Receiver;
                        pair.Receiver = pair2.Receiver;
                        pair2.Receiver = temp;
                    }
                    else
                        noMatchCounter++;
                }
            } while ((List.Where(p => !p.IsValid).Count() > 0) && (noMatchCounter < 3));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!IsValidList) builder.AppendLine(INVALID_LIST);
            foreach (var pair in List)
                builder.AppendLine(string.Format("{0}\t{1}",
                    pair.ToString(), (!pair.IsValid) ? pair.IsValid.ToString() : string.Empty));
            return builder.ToString();
        }
    }
}
