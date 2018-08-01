using Playing.Cards;
using Playing.Poker.Hands;
using System.Collections.Generic;

namespace Playing.Poker.Handlers
{
    public abstract class Handler
    {
        protected Handler(Handler nextHandler)
        {
            NextHandler = nextHandler;
        }

        protected Handler NextHandler { get; private set; }

        abstract public Hand Handle(List<Card> cards);
    }
}
