using System;

namespace AsciiRogueLike
{
    public class Draw
    {
        private static int maxX = 20;
        private static int maxY = 20;

        /// <summary>
        /// Set Draw Color
        /// </summary>
        public static void SetColor(ConsoleColor C)
        {
            Console.BackgroundColor = C;
        }

        /// <summary>
        /// Change Console and Buffer Size
        /// </summary>
        public static void SetSize(int X, int Y)
        {
            Console.SetWindowSize(X, Y);
            Console.SetBufferSize(X, Y);
            maxX = X;
            maxY = Y;
        }

        public static void Point(int X, int Y, char C = ' ')
        {
            if (X >= 0 && Y >= 0 && X < maxX && Y < maxY)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(C);
            }
        }

        public static void Line(int X, int Y, int L, char C = ' ')
        {
            for (int i = L; i > 0; i--)
            {
                Point(X + i, Y, C);
            }
        }

        public static void Begin(ConsoleColor C)
        {
            SetColor(C);
            Console.Clear();
        }

        public static void End()
        {
            Console.SetCursorPosition(maxX - 1, maxY - 1);
        }
    }
}