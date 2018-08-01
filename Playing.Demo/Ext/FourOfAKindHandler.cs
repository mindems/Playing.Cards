using Playing.Cards;
using Playing.Poker.Handlers;
using Playing.Poker.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playing.Demo.Ext
{
    class FourOfAKindHandler : Handler
    {
        public FourOfAKindHandler(Handler nextHandler)
            : base(nextHandler) { }

        override public Hand Handle(List<Card> cards)
        {
            var groups =
                    cards
                        .GroupBy(c => c.Rank)
                        .Select(g => new { Rank = g.Key, Count = g.Count(), Cards = g.ToList() });

            var fourOfAKind = groups.SingleOrDefault(g => g.Count == 4);

            if (fourOfAKind == null) return NextHandler.Handle(cards);

            Card kicker =
                    cards
                        .Where(c => c.Rank != fourOfAKind.Rank)
                        .First();

            cards = fourOfAKind.Cards;
            cards.Add(kicker);

            return new FourOfAKind(cards, fourOfAKind.Rank, kicker.Rank);
        }
    }
}
