using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Solutions.Problem1;
using NUnit.Framework;

namespace Tests.Problem1
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Cards_IsCompleteDeck_WithoutJokers()
        {
            Deck deck = new Deck(false);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52 });
            //List<int> manualDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52 };
            
            Assert.AreEqual(manualDeck.Cards.OrderBy(c => c), deck.Cards.OrderBy(c => c));
        }
        [Test]
        public void Cards_IsCompleteDeck_WithJokers()
        {
            Deck deck = new Deck(true);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 });
            //List<int> manualDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 };
            
            Assert.AreEqual(manualDeck.Cards.OrderBy(c => c), deck.Cards.OrderBy(c => c));
        }

        [Test]
        public void Deck_Equal()
        {
            Deck deck = new Deck(true);
            Assert.AreEqual(new Deck(true), deck);
        }
        [Test]
        public void Deck_NotEqual()
        {
            Deck deck = new Deck(true);
            deck.MoveCardDown(CardValue.NineOfClubs, 5);
            Assert.AreNotEqual(new Deck(true), deck);
        }

        [Test]
        public void Deck_Reset()
        {
            Deck deck = new Deck(true);
            deck.MoveCardDown(CardValue.AceOfHearts, 10);
            deck.MoveCardDown(CardValue.NineOfClubs, 5);

            deck.Reset();

            Assert.AreEqual(new Deck(true), deck);
        }

        [Test]
        public void Cards_AreOrdered_WithoutJokers()
        {
            Deck deck = new Deck(false);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52 });
            //List<int> manualDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52 };
            
            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void Cards_AreOrdered_WithJokers()
        {
            Deck deck = new Deck(true);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 });
            //List<int> manualDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 };
            
            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }

        [Test]
        public void Cards_CardIsNotAJoker()
        {
            Assert.AreEqual(false, Deck.IsJoker(CardValue.AceOfClubs));
        }
        [Test]
        public void Cards_CardIsAJoker()
        {
            Assert.AreEqual(true, Deck.IsJoker(CardValue.JokerA));
        }

        [Test]
        public void Cards_IndexOfCard()
        {
            Deck deck = new Deck(true);
            CardValue card = CardValue.FourOfClubs;

            Assert.AreEqual(3, deck.IndexOfCard(card));
        }

        [Test]
        public void Move_SingleCardDownOne_WithinCardLength()
        {
            Deck deck = new Deck(true);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 3, 5, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 });
            //List<int> manualDeck = new List<int>() { 1, 2, 3, 5, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 };

            CardValue card = CardValue.FourOfClubs;
            deck.MoveCardDown(card, 1);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void Move_SingleCardDownTwo_WithinCardLength()
        {
            Deck deck = new Deck(true);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 3, 5, 6, 4, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 });
            //List<int> manualDeck = new List<int>() { 1, 2, 3, 5, 6, 4, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 };

            CardValue card = CardValue.FourOfClubs;
            deck.MoveCardDown(card, 2);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void Move_SingleCardDownOne_BeyondCardLength()
        {
            Deck deck = new Deck(true);
            Deck manualDeck = new Deck(new List<int>() { 1, 54, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 });
            //List<int> manualDeck = new List<int>() { 1, 54, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 };

            CardValue card = CardValue.JokerB;
            deck.MoveCardDown(card, 1);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void Move_SingleCardDownTwo_BeyondCardLength()
        {
            Deck deck = new Deck(true);
            Deck manualDeck = new Deck(new List<int>() { 1, 2, 54, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 });
            //List<int> manualDeck = new List<int>() { 1, 2, 54, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 };

            CardValue card = CardValue.JokerB;
            deck.MoveCardDown(card, 2);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }

        [Test]
        public void TripleCut_FlopTwoSections_NodeCardsCorrectOrder()
        {
            Deck deck = new Deck(new List<int>() { 1, 2, 3, 54, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 51, 52 });
            Deck manualDeck = new Deck(new List<int>() { 51, 52, 54, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 1, 2, 3 });
            //List<int> manualDeck = new List<int>() { 51, 52, 54, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 1, 2, 3 };

            CardValue card1 = CardValue.JokerB;
            CardValue card2 = CardValue.JokerA;
            deck.TripleCut(card1, card2);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void TripleCut_FlopTwoSections_NodeCardsIncorrectOrder()
        {
            Deck deck = new Deck(new List<int>() { 1, 2, 3, 54, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 51, 52 });
            Deck manualDeck = new Deck(new List<int>() { 51, 52, 54, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 1, 2, 3 });
            //List<int> manualDeck = new List<int>() { 51, 52, 54, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 1, 2, 3 };

            CardValue card1 = CardValue.JokerB;
            CardValue card2 = CardValue.JokerA;
            deck.TripleCut(card2, card1);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void TripleCut_FlopOneSection_NodeCardsCorrectOrder()
        {
            Deck deck = new Deck(new List<int>() { 54, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53, 51, 52 });
            Deck manualDeck = new Deck(new List<int>() { 51, 52, 54, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53 });
            //List<int> manualDeck = new List<int>() { 51, 52, 54, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 53 };

            CardValue card1 = CardValue.JokerB;
            CardValue card2 = CardValue.JokerA;
            deck.TripleCut(card1, card2);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void TripleCut_FlopZeroSection_NodeCardsCorrectOrder()
        {
            Deck deck = new Deck(new List<int>() { 54, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 });
            Deck manualDeck = new Deck(new List<int>() { 54, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 });
            //List<int> manualDeck = new List<int>() { 54, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 };

            CardValue card1 = CardValue.JokerB;
            CardValue card2 = CardValue.JokerA;
            deck.TripleCut(card1, card2);

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
                
        [Test]
        public void CountCut_LessThanWholeDeck()
        {
            Deck deck = new Deck(new List<int>() { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 2 });
            Deck manualDeck = new Deck(new List<int>() { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 1, 3, 2 });
            //List<int> manualDeck = new List<int>() { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 1, 3, 2 };

            deck.CountCut();

            Assert.AreEqual(manualDeck.Cards, deck.Cards);
        }
        [Test]
        public void CountCut_WholeDeck()
        {
            Deck deck = new Deck(true);
            deck.CountCut();

            Assert.AreEqual(new Deck(true).Cards, deck.Cards);
        }
    }
}
