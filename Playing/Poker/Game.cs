using Playing.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playing.Poker
{
    public class Game
    {
        private readonly int numberOfPlayers;
        private readonly ISolve solver;
        private readonly Deck deck;

        public Game(int numberOfPlayers, ISolve solver)
        {
            if (numberOfPlayers < 2 || numberOfPlayers > 20) throw new ArgumentException("numberOfPlayers");
            this.numberOfPlayers = numberOfPlayers;
            this.solver = solver ?? throw new ArgumentNullException("solver");
            deck = new Deck();

            Players = new List<Player>();
        }

        public List<Card> Table { get; private set; }
        public List<Player> Players { get; private set; }

        public Game Play()
        {
            Initialize();
            Deal();
            Evaluate();

            return this;
        }

        private void Initialize()
        {
            deck.Initialize();
            Players.Clear();
        }

        private void Deal()
        {
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Players.Add(
                    new Player(
                        $"Player {i}",
                        deck.Deal(2)));
            }

            Table = deck.Deal(5);
        }

        private void Evaluate()
        {
            solver.RateHands(Players, Table);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"New Game: {numberOfPlayers} Players\n===================\n\n");

            sb.AppendLine("Game Stats:\n===========");
            foreach(Player player in Players)
            {
                sb.AppendLine($"\t{player.Ranking}: {player.Name} - {player.Hand}");
            }
            sb.AppendLine();

            sb.AppendLine("Poker Hands:\n============");
            foreach (Player player in Players)
            {
                sb.AppendLine($"{player.Name} Hand:");
                foreach (Card card in player.Hand.Cards)
                {
                    sb.AppendLine($"\t{card}");
                }
            }
            sb.AppendLine();

            sb.AppendLine("All Cards:\n==========");
            foreach (Player player in Players)
            {
                sb.AppendLine($"{player.Name}:");
                foreach(Card card in player.HoleCards)
                {
                    sb.AppendLine($"\t{card}");
                }
            }

            sb.AppendLine($"Table:");
            foreach (Card card in Table)
            {
                sb.AppendLine($"\t{card}");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
