using Playing.Cards;
using Playing.Poker.Handlers;
using Playing.Poker.Hands;
using System;
using System.Collections.Generic;

namespace Playing.Poker
{
    public class Solver : ISolve
    {
        private readonly Handler handlers;

        public Solver(Handler handlers)
        {
            this.handlers = handlers ?? throw new ArgumentNullException("handlers");
        }

        public void RateHands(List<Player> players, List<Card> communityCards)
        {
            players.ForEach(p => p.Hand = CalculateHand(p.HoleCards, communityCards));
            players.Sort((p1, p2) => p2.Hand.CompareTo(p1.Hand));
            SetRanking(players);
        }

        private Hand CalculateHand(List<Card> holeCards, List<Card> communityCards)
        {
            if (holeCards.Count + communityCards.Count != 7) throw new ArgumentException("cards");

            List<Card> cards = new List<Card>();
            cards.AddRange(holeCards);
            cards.AddRange(communityCards);
            cards.Sort();

            return handlers.Handle(cards);
        }

        private void SetRanking(List<Player> players)
        {
            players[0].Ranking = 1;

            for (int i = 1; i < players.Count; i++)
            {
                players[i].Ranking = 
                    players[i].Hand.CompareTo(players[i - 1].Hand) == 0 
                        ? players[i - 1].Ranking
                        : players[i - 1].Ranking + 1;
            }
        }
    }
}
