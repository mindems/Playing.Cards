using System;

namespace Playing.Cards
{
    public class Card : IComparable<Card>
    {
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public int CompareTo(Card other)
        {
            return other.Rank.CompareTo(this.Rank);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
