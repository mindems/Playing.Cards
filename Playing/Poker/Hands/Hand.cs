using Playing.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Playing.Poker.Hands
{
    public abstract class Hand : IComparable<Hand>
    {
        public Hand(TypeOfHand type, List<Card> cards)
        {
            Type = type;

            if (cards == null) throw new ArgumentNullException("cards");
            if (cards.Count != 5) throw new ArgumentException("cards");
            Cards = new List<Card>(cards);
        }

        public TypeOfHand Type { get; private set; }
        public List<Card> Cards { get; private set; }

        public int CompareTo(Hand other)
        {
            return this.Type == other.Type
                ? CompareSameHands(this, other)
                : this.Type.CompareTo(other.Type);
        }

        virtual protected int CompareSameHands(Hand h1, Hand h2)
        {
            return WeightedSum(h1).CompareTo(WeightedSum(h2));
        }

        protected int WeightedSum(Hand hand)
        {
            return hand.Cards.Sum(c => (int)c.Rank);
        }

        public enum TypeOfHand
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            FiveOfAKind
        }
    }
}
