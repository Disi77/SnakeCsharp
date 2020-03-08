using System;


namespace Snake
{
    /// <summary>
    /// One Fruit
    /// </summary>
    class Fruit: Part
    {
        /// <summary>
        /// Create new fruit with coordinates x and y and with default color. 
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        public Fruit(int x, int y): base(x, y)
        {
            Color = ConsoleColor.Red;
        }
    }
}
