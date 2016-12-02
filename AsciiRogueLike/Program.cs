using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiRogueLike
{
    class Program
    {
        private static int[,] map = new int[10,10]{
            {1,1,1,1,2,1,1,1,1,1},
            {0,0,0,2,2,0,0,0,0,1},
            {1,0,0,2,1,2,0,0,0,0},
            {0,0,2,1,1,2,0,0,0,1},
            {1,0,0,1,1,1,0,0,0,0},
            {0,0,0,1,1,0,0,0,0,1},
            {1,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1}
            };

        private static int playerX = 4;
        private static int playerY = 4;
        private static int playerLive = 1;

        static void Main(string[] args)
        {
            Console.Title = "Ascii RogueLike";
            Draw.SetSize(105, 33);
            while (playerLive > 0)
            {
                Draw.Begin(ConsoleColor.Black);
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        DrawPos(x, y);   
                    }
                }
                DrawPlayer(playerX, playerY);
                Draw.End();
                bool redraw = false;
                while (!redraw)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.RightArrow:
                            int newX = MoveX(key.Key, playerX, playerY);
                            int newY = MoveY(key.Key, playerY);
                            if (newX < 0 || newY < 0 || newX >= 10 || newY >= 10)
                                break;

                            if (map[newY, newX] != 1)
                                break;

                            DrawPos(playerX, playerY, false);
                            DrawPlayer(newX, newY);

                            playerX = newX;
                            playerY = newY;

                            //redraw = true;
                            break;

                        case ConsoleKey.Escape:
                            playerLive--;
                            break;
                    }
                }
            }
        }

        static void DrawPos(int X, int Y, bool grid = true)
        {
            int x = IsoX(X, Y);
            int y = IsoY(Y);
            switch (map[Y, X])
            {
                case 1:
                    if(grid)
                        DrawTile.Grid(x, y);

                    DrawTile.Ground(x, y);
                    break;

                case 2:
                    if(grid)
                        DrawTile.Grid(x, y);

                    DrawTile.Wall(x, y);
                    break;
            }
        }

        static void DrawPlayer(int X, int Y)
        {
            DrawTile.Ground(IsoX(X, Y), IsoY(Y), ConsoleColor.Red);
        }

        static int IsoX(int X, int Y)
        {
            return X * 10 + (Y % 2 == 0 ? 0 : 5);
        }
        
        static int IsoY(int Y)
        {
            return Y * 3;
        }

        static int MoveX(ConsoleKey K, int X, int Y)
        {
            int newX = X;
            switch (K)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.RightArrow:
                    if (Y % 2 != 0)
                        newX++;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                    if (Y % 2 == 0)
                        newX--;
                    break;
            }
            return newX;
        }

        static int MoveY(ConsoleKey K, int Y)
        {
            int newY = Y;
            switch (K)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                    newY--;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                    newY++;
                    break;
            }
            return newY;
        }
    }
}