## Playing.Cards

1. A library project providing partial Poker functionality:

   - Full House
   - Flush
   - Straight
   - High Card
     

   Exposes an API to extend that functionality.

   ```
   public Game(int numberOfPlayers, ISolve solver) 
   ```

   

2. A console app to simulate composition root.
   

   - A variation on *Chain of Responsibility* indicates the order of winning hands. A first region uses baked-in behavior. 

     ```
     #region Composition Root
     Game game = new Game(
         4,
         new Solver(
             new FullHouseHandler(
                 new FlushHandler(
                     new StraightHandler(
                         new HighCardHandler())))));
     #endregion
     ```

     

   - The second region uses classes from the console project to extend functionality with the `FourOfAKind` hand.

     ```
     #region Composition Root Ext
     Game game = new Game(
         4,
         new Solver(
             new Ext.FourOfAKindHandler(
                 new FullHouseHandler(
                     new FlushHandler(
                         new StraightHandler(
                             new HighCardHandler()))))));
     #endregion
     ```

