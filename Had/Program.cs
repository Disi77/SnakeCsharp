using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ovoce noveOvoce = new Ovoce(Console.WindowWidth, Console.WindowHeight);
            //bool a = noveOvoce.fruits.Contains(new Fruit(10, 10));
            //Console.WriteLine(noveOvoce.fruits[0].Y);

            GameField newGame = new GameField();
            Console.ReadKey();           
        }
    }
}
