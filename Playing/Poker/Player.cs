using Playing.Cards;
using Playing.Poker.Hands;
using System;
using System.Collections.Generic;

namespace Playing.Poker
{
    public class Player
    {
        public Player(string name, List<Card> holeCards)
        {
            Name = name ?? throw new ArgumentNullException("name");
            HoleCards = holeCards ?? throw new ArgumentNullException("holeCards");
        }

        public string Name { get; private set; }
        public List<Card> HoleCards { get; private set; }

        public Hand Hand { get; set; }
        public int Ranking { get; set; }
    }
}
