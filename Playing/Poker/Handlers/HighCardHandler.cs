using Playing.Cards;
using Playing.Poker.Hands;
using System.Collections.Generic;
using System.Linq;

namespace Playing.Poker.Handlers
{
    public class HighCardHandler : Handler
    {
        public HighCardHandler()
            : base(null) { }

        override public Hand Handle(List<Card> cards)
        {
            while(cards.Count() > 5)
            {
                cards.RemoveAt(cards.Count() - 1); // O(1)
            }
            return new HighCard(cards);
        }
    }
}