using System;
using System.Collections.Generic;

namespace Snake
{
    class Snake
    {
        /// <summary>
        /// Snake is (true) or is not alive (false)
        /// </summary>
        public bool Alive { get; set; }
        /// <summary>
        /// List of snake parts
        /// </summary>
        public List<Part> snakeParts;
        /// <summary>
        /// Direction of snake´s movement
        /// </summary>
        public int Direction { get; set; }
        /// <summary>
        /// Width of game field - where can snake move
        /// </summary>
        private int width;
        /// <summary>
        /// Height of game field - where can snake move
        /// </summary>
        private int height;

        /// <summary>
        /// Creation of new snake with 3 parts, direction and width and height of space, where can snake move
        /// </summary>
        /// <param name="w">width of game field - where can snake move</param>
        /// <param name="h">height of game field - where can snake move</param>
        public Snake(int w, int h)
        {
            Alive = true;
            snakeParts = new List<Part>
            {
                new Part(3, 3),
                new Part(3, 4),
                new Part(3, 5)
            };

            Direction = 270;
            width = w;
            height = h;
        }

        /// <summary>
        /// Drawing of a snake, each even part has one color and odd part different color
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < snakeParts.Count; i++)
            {
                Console.CursorLeft = snakeParts[i].X * 2; 
                Console.CursorTop = snakeParts[i].Y;
                if (i % 2 == 0)
                    Console.ForegroundColor = snakeParts[i].Color;
                else
                    Console.ForegroundColor = snakeParts[i].Color2;
                Console.Write("██");
            }
        }
        /// <summary>
        /// Next step - movement of snake, solving situation like: snake is out of game field, snake eats itself, snake eats fruit
        /// </summary>
        /// <param name="fruits">list of fruit, which can snake eats</param>
        public void NextStep(FruitsInGame fruits)
        {
            Part head = snakeParts[snakeParts.Count-1];
            int x = head.X;
            int y = head.Y;

            switch (Direction)
            {
                case 0:
                    // Right
                    x++;
                    break;
                case 90:
                    // Up
                    y--;
                    break;
                case 180:
                    // Left
                    x--;
                    break;
                case 270:
                    // Down
                    y++;
                    break;
            }

            // Snake is or is not out of game field
            if (x >= (width/2) | x < 0 | y >= height | y < 0)
                Alive = false;

            // Snake eats itself
            for (int j = 0; j < snakeParts.Count; j++)
            {
                int snake_x = snakeParts[j].X;
                int snake_y = snakeParts[j].Y;
                if (snake_x == x && snake_y == y)
                {
                    Alive = false;                
                }
            }

            Part newHead = new Part(x, y);
            snakeParts.Add(newHead);

            // Snake eats fruit 
            bool snakeAteFruit = false;
            for (int i = 0; i < fruits.fruitsCoordinates.Count; i++)
            {
                int fruit_x = fruits.fruitsCoordinates[i].X;
                int fruit_y = fruits.fruitsCoordinates[i].Y;
                if (fruit_x == x && fruit_y == y)
                {
                    fruits.fruitsCoordinates.RemoveAt(i);
                    snakeAteFruit = true;
                    break;
                }            
            }

            // Snake didnt eat fruit
            if (!snakeAteFruit)
                snakeParts.RemoveAt(0);
        }
    }
}
