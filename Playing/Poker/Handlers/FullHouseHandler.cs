using Playing.Cards;
using Playing.Poker.Hands;
using System.Collections.Generic;
using System.Linq;

namespace Playing.Poker.Handlers
{
    public class FullHouseHandler : Handler
    {
        public FullHouseHandler(Handler nextHandler)
            : base(nextHandler) { }

        override public Hand Handle(List<Card> cards)
        {
            var groups =
                    cards
                        .GroupBy(c => c.Rank)
                        .Select(g => new { Rank = g.Key, Count = g.Count(), Cards = g.ToList() });

            var tripletGroups = groups.Where(g => g.Count == 3).ToList();
            var pairGroups = groups.Where(g => g.Count == 2).ToList();

            if (tripletGroups.Count == 0 || pairGroups.Count == 0) return NextHandler.Handle(cards);

            var triplet = tripletGroups.Single();
            var pair = 
                    pairGroups.Count == 2 
                        ? pairGroups.Find(p => p.Rank == pairGroups.Max(g => g.Rank))
                        : pairGroups.Single();

            cards = triplet.Cards;
            cards.AddRange(pair.Cards);

            return new FullHouse(cards, triplet.Rank, pair.Rank);
        }
    }
}
