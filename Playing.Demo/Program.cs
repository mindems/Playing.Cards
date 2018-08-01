using Playing.Poker;
using Playing.Poker.Handlers;
using System;

namespace Playing.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Composition Root
            Game game = new Game(
                4,
                new Solver(
                    new FullHouseHandler(
                        new FlushHandler(
                            new StraightHandler(
                                new HighCardHandler())))));
            #endregion

            #region Composition Root Ext
            //Game game = new Game(
            //    4,
            //    new Solver(
            //        new Ext.FourOfAKindHandler(
            //            new FullHouseHandler(
            //                new FlushHandler(
            //                    new StraightHandler(
            //                        new HighCardHandler()))))));
            #endregion

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(game.Play());
            }

            Console.ReadKey();
        }
    }
}