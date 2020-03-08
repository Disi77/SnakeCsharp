using System;


namespace Snake
{
    /// <summary>
    /// Part of snake
    /// </summary>
    class Part
    {
        /// <summary>
        /// X-coordinate of Part
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y-coordinate of Part
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Default color of Part
        /// </summary>
        public ConsoleColor Color { get; set; }
        /// <summary>
        /// Default sesond color of Part
        /// </summary>
        public ConsoleColor Color2 { get; set; }
        /// <summary>
        /// Create new part with coordinates x and y and with default colors. 
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        public Part(int x, int y)
        {
            X = x;
            Y = y;
            Color = ConsoleColor.DarkBlue;
            Color2 = ConsoleColor.DarkGreen;
        }
    }
}
