using System;

namespace AsciiRogueLike
{
    internal class DrawTile
    {
        public static void Grid(int X, int Y)
        {
            Draw.SetColor(ConsoleColor.DarkGray);
            Draw.Point(X + 9, Y + 2);
            Draw.Line(X, Y + 3, 2);
            Draw.Line(X + 7, Y + 3, 2);
            Draw.Line(X + 2, Y + 4, 2);
            Draw.Line(X + 5, Y + 4, 2);
            Draw.Point(X + 5, Y + 5);
        }

        public static void Ground(int X, int Y, ConsoleColor C = ConsoleColor.White)
        {
            Draw.SetColor(C);
            Draw.Point(X + 5, Y);
            Draw.Line(X + 2, Y + 1, 5);
            Draw.Line(X, Y + 2, 9);
            Draw.Line(X + 2, Y + 3, 5);
            Draw.Point(X + 5, Y + 4);
        }

        public static void Wall(int X, int Y)
        {
            Draw.SetColor(ConsoleColor.Gray);
            Draw.Point(X + 5, Y - 4);
            Draw.Line(X + 2, Y - 3, 5);
            Draw.Line(X, Y - 2, 9);
            Draw.Line(X + 2, Y - 1, 5);
            Draw.Line(X, Y, 2);
            Draw.Point(X + 5, Y);
            Draw.Line(X + 7, Y, 2);
            Draw.Line(X, Y + 1, 4);
            Draw.Line(X + 5, Y + 1, 4);
            Draw.Line(X, Y + 2, 4);
            Draw.Line(X + 5, Y + 2, 4);
            Draw.Line(X + 2, Y + 3, 2);
            Draw.Line(X + 5, Y + 3, 2);

            Draw.SetColor(ConsoleColor.DarkGray);
            Draw.Point(X + 10, Y - 2);
            Draw.Line(X, Y - 1, 2);
            Draw.Line(X + 7, Y - 1, 3);
            Draw.Line(X + 2, Y, 2);
            Draw.Line(X + 5, Y, 2);
            Draw.Point(X + 10, Y);
            Draw.Point(X + 5, Y + 1);
            Draw.Point(X + 10, Y + 1);
            Draw.Point(X + 5, Y + 2);
            Draw.Point(X + 10, Y + 2);
            Draw.Point(X + 5, Y + 3);
            Draw.Point(X + 5, Y + 4);
        }
    }
}