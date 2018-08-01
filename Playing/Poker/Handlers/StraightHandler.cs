using System;
using System.Collections.Generic;
using System.Linq;
using Playing.Cards;
using Playing.Poker.Hands;

namespace Playing.Poker.Handlers
{
    public class StraightHandler : Handler
    {
        public StraightHandler(Handler nextHandler)
            : base(nextHandler) { }

        override public Hand Handle(List<Card> cards)
        {
            HashSet<int> ranks = new HashSet<int>(cards.Select(g => (int)g.Rank));

            // Aces go both ways
            bool aceInPlay = ranks.Contains((int)Rank.Ace);
            int sum =
                    aceInPlay
                        ? ranks.Sum() + 1
                        : ranks.Sum();

            string binary = Convert.ToString(sum, 2);

            bool isStraight =
                    binary
                        .Split('0')
                        .Any(s => s.Length > 4);

            if (!isStraight) return NextHandler.Handle(cards);

            int highestIndex = binary.Length - 1 - binary.IndexOf("11111");

            List<Card> temp = new List<Card>();
            // Five-High Straight
            if (highestIndex == 4) 
            {
                for (int i = 0; i < 4; i++)
                {
                    temp.Add(cards.First(c => c.Rank == RankFor(highestIndex - i)));
                }
                temp.Add(cards.First(c => c.Rank == Rank.Ace));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    temp.Add(cards.First(c => c.Rank == RankFor(highestIndex - i)));
                }
            }

            return new Straight(cards = temp);
        }

        private Rank RankFor(int index) => (Rank)Math.Pow(2, index);
    }
}