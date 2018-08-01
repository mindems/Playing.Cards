using Playing.Cards;
using Playing.Poker.Hands;
using System.Collections.Generic;
using System.Linq;

namespace Playing.Poker.Handlers
{
    public class FlushHandler : Handler
    {
        public FlushHandler(Handler nextHandler)
            : base(nextHandler) { }

        override public Hand Handle(List<Card> cards)
        {
            var groups =
                    cards
                        .GroupBy(c => c.Suit)
                        .Select(g => new { Cards = g.ToList(), Count = g.Count() });

            var flush = groups.SingleOrDefault(g => g.Count >= 5);

            if (flush == null) return NextHandler.Handle(cards);

            cards = flush.Cards;
            while(cards.Count > 5)
            {
                cards.RemoveAt(cards.Count() - 1); // O(1)
            }

            return new Flush(cards);
        }
    }
}
