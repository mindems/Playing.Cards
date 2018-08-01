using System;
using System.Collections.Generic;

namespace Playing.Cards
{
    internal class Deck
    {
        private readonly Random random;
        private Stack<Card> cards;

        public Deck()
        {
            random = new Random();
            cards = new Stack<Card>();
        }

        public void Initialize()
        {
            NewDeck();
            Shuffle();
        }

        private void NewDeck()
        {
            cards.Clear();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Push(new Card(suit, rank));
                }
            }
        }

        private void Shuffle()
        {
            Card temp;
            Card[] array = cards.ToArray();

            for (int i = array.Length - 1; i > 0; i--)
            {
                temp = array[i];
                int index = random.Next(0, i + 1);
                array[i] = array[index];
                array[index] = temp;
            }

            cards = new Stack<Card>(array);
        }

        public List<Card> Deal(int numberOfCards)
        {
            IEnumerable<Card> TakeTop(int n)
            {
                for (int i = 0; i < numberOfCards; i++)
                {
                    yield return cards.Pop();
                }
            }
            return new List<Card>(TakeTop(numberOfCards));
        }
    }
}
