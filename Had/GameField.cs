using System;
using System.Threading;


namespace Snake
{
    class GameField
    {
        public int gameFieldWidth = Console.WindowWidth;
        public int gameFieldHeight = Console.WindowHeight;

        public GameField()
        {
            Game();
        }

        public void Game()
        { 
            Snake snake = new Snake(gameFieldWidth, gameFieldHeight);
            FruitsInGame fruits = new FruitsInGame(gameFieldWidth, gameFieldHeight);
            while (snake.Alive) 
            {

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.CursorVisible = false;
                snake.Draw();
                fruits.Draw();
                snake.NextStep(fruits);
                fruits.Add(snake);
                Thread.Sleep(200); 
                                  
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klavesa = Console.ReadKey(); 
                    if (klavesa.Key == ConsoleKey.RightArrow)
                        snake.Direction = 0;
                    if (klavesa.Key == ConsoleKey.LeftArrow)
                        snake.Direction = 180;
                    if (klavesa.Key == ConsoleKey.DownArrow)
                        snake.Direction = 270;
                    if (klavesa.Key == ConsoleKey.UpArrow)
                        snake.Direction = 90;
                    if (klavesa.Key == ConsoleKey.P)
                        Console.ReadKey();
                }
            }
            Console.SetCursorPosition(0, 20);
            GameOver();
        }
        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            string text =

                @"      _______  _______  _______  _______   _______           _______  ________" + "\n" +
                @"     (  ____ \(  ___  )(       )(  ____ \ (  ___  )|\     /|(  ____ \(  ____  )" + "\n" +
                @"     | (    \/| (   ) || () () || (    \/ | (   ) || )   ( || (    \/| (    ) |" + "\n" +
                @"     | |      | (___) || || || || (__     | |   | || |   | || (__    | (____) |" + "\n" +
                @"     | | ____ |  ___  || |(_)| ||  __)    | |   | |( (   ) )|  __)   |      __)" + "\n" +
                @"     | | \_  )| (   ) || |   | || (       | |   | | \ \_/ / | (      | (\ (" + "\n" +
                @"     | (___) || )   ( || )   ( || (____/\ | (___) |  \   /  | (____/\| ) \ \__" + "\n" +
                @"     (_______)|/     \||/     \|(_______/ (_______)   \_/   (_______/|/   \___/";

            Console.WriteLine(text);

        }


    }
}
