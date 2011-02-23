using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Problem1
{
    public class Deck
    {
        #region Constants
        public static readonly Func<CardValue, bool> IsJoker = card => (((int)card > 52) && ((int)card < 55));
        #endregion Constants

        #region Members
        private List<CardValue> _originalDeck;
        #endregion Members

        #region Properties
        public IEnumerable<CardValue> Cards { get; private set; }
        #endregion Properties

        #region Constructors
        public Deck(bool includeJokers)
        {
            List<CardValue> cardValues = new List<CardValue>();
            foreach (CardValue card in Enum.GetValues(typeof(CardValue)))
                if (!IsJoker(card) || includeJokers)
                    cardValues.Add(card);

            Cards = cardValues.OrderBy(c => c).ToList();
            _originalDeck = Cards.ToList();
        }
        public Deck(IEnumerable<CardValue> cards)
        {
            Cards = cards.ToList();
            _originalDeck = Cards.ToList();
        }
        public Deck(IEnumerable<int> cards)
        {
            List<CardValue> cardValues = new List<CardValue>();
            foreach (int c in cards)
                cardValues.Add((CardValue)c);

            Cards = cardValues;
            _originalDeck = Cards.ToList();
        }
        #endregion Constructors

        #region Methods
        public void Reset()
        {
            Cards = _originalDeck;
        }

        public int IndexOfCard(CardValue card)
        {
            return Cards.ToList().IndexOf(card);
        }
        public void MoveCardDown(CardValue card, int amount)
        {
            int oldIndex = IndexOfCard(card);
            int newIndex = oldIndex + amount;
            newIndex -= (newIndex >= (Cards.Count())) ? Cards.Count() - 1 : 0;

            List<CardValue> cards = Cards.Where(c => c != card).ToList();
            cards.Insert(newIndex, card);

            Cards = cards;
        }

        public void TripleCut(CardValue card1, CardValue card2)
        {
            List<CardValue> nodeCards = new List<CardValue>() { card1, card2 };
            CardValue firstNodeCard = Cards.First(c => nodeCards.Contains(c));
            CardValue secondNodeCard = Cards.Last(c => nodeCards.Contains(c));

            List<CardValue> section1 = Cards.TakeWhile(c => c != firstNodeCard).ToList();
            List<CardValue> section2 = Cards.Reverse().TakeWhile(c => c != secondNodeCard).Reverse().ToList();

            Cards = section2.Concat(Cards.Except(section2).Except(section1)).Concat(section1).ToList();
        }
        public void CountCut()
        {
            CardValue nodeCard = Cards.Last();
            Func<CardValue, bool> NotNodeCard = c => c != nodeCard;
            List<CardValue> topCards = Cards.Take((int)nodeCard).Where(NotNodeCard).ToList();

            Cards = (Cards.Except(topCards).Where(NotNodeCard)).Concat(topCards).Concat(new List<CardValue>() { nodeCard }).ToList();
        }
        #endregion Methods

        #region Public Methods
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Deck)) return false;

            return Equals(obj as Deck);
        }
        public bool Equals(Deck otherDeck)
        {
            if (otherDeck == null) return false;

            return Cards.SequenceEqual(otherDeck.Cards);
        }
        #endregion Public Methods

        #region Static Methods
        #endregion Static Methods
    }
}
