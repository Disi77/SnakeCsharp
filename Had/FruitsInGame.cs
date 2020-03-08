
using System;
using System.Collections.Generic;

namespace Snake
{
    class FruitsInGame
    {
        /// <summary>
        /// Count of fruit in game
        /// </summary>
        public int CountInGame { get; set; }
        /// <summary>
        /// Maximum of fruit in game
        /// </summary>
        public int CountInGameMax { get; set; }

        /// <summary>
        /// Time of last adding fruit into game
        /// </summary>
        public long TimeOfAddingFruit;

        /// <summary>
        /// List of fruits in game
        /// </summary>
        public List<Fruit> fruitsCoordinates;

        public Random random;
        /// <summary>
        /// Width of game field - where fruit can be placed
        /// </summary>
        private int width;
        /// <summary>
        /// Height of game field - where fruit can be placed
        /// </summary>
        private int height;

        public FruitsInGame(int w, int h)
        {
            CountInGameMax = 10;
            random = new Random();

            fruitsCoordinates = new List<Fruit>();
            fruitsCoordinates.Add(new Fruit(10, 10));
            CountInGame = fruitsCoordinates.Count;
            width = w;
            height = h;
            TimeOfAddingFruit = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Drawing of fruits in game
        /// </summary>
        public void Draw()
        {
            foreach (Fruit f in fruitsCoordinates)
            {
                Console.CursorLeft = f.X * 2; 
                Console.CursorTop = f.Y;
                Console.ForegroundColor = f.Color;
                Console.Write("██");
            }
        }

        /// <summary>
        /// Add new fruit into game
        /// </summary>
        /// <param name="had"></param>
        public void Add(Snake had)
        {
            CountInGame = fruitsCoordinates.Count;
            if (CountInGameMax > CountInGame)
            {
                int tick = 4*10000000;
                if (TimeOfAddingFruit + tick < DateTime.Now.Ticks)
                {
                    while (true)
                    {
                        int x = random.Next(width / 2);
                        int y = random.Next(height);
                        if (!fruitsCoordinates.Contains(new Fruit(x, y)) && !had.snakeParts.Contains(new Part(x, y)))
                        {
                            fruitsCoordinates.Add(new Fruit(x, y));
                            TimeOfAddingFruit = DateTime.Now.Ticks;
                            break;
                        }
                    }
                }                                
            }
        }
    }
}
