using System;

namespace AsciiRogueLike
{
    internal class Program
    {
        private static int[,] map = new int[10, 10]{    //Game Map
            {0,0,0,0,2,0,0,0,0,0},
             {0,0,0,2,2,0,0,0,0,0},
            {0,0,0,2,1,2,0,0,0,0},
             {0,0,2,1,1,2,0,0,0,0},
            {0,0,0,1,1,1,0,0,0,0},
             {0,0,0,1,1,0,0,0,0,0},
            {0,0,0,1,1,1,0,0,0,0},
             {0,0,1,0,0,1,0,0,0,0},
            {0,0,0,1,1,1,0,0,0,0},
             {0,0,0,1,1,0,0,0,0,0}
            };

        private static Player player = new Player(4, 4, 1); //Player struct (X, Y, Live)

        private static void Main(string[] args)
        {
            //Init
            Console.Title = "Ascii RogueLike";
            Draw.SetSize(105, 33);

            //Game
            while (player.Live > 0)
            {
                Draw.Begin(ConsoleColor.Black);
                for (int y = 0; y < 10; y++)    //Draw map
                {
                    for (int x = 0; x < 10; x++)
                    {
                        DrawPos(x, y);
                    }
                }
                DrawPlayer(player.X, player.Y); //Draw player
                Draw.End();
                bool redraw = false;
                while (!redraw)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow: //Player move
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.RightArrow:
                            int newX = MoveX(key.Key, player.X, player.Y);
                            int newY = MoveY(key.Key, player.Y);
                            if (newX < 0 || newY < 0 || newX >= 10 || newY >= 10)
                                break;

                            if (map[newY, newX] != 1)
                                break;

                            DrawPos(player.X, player.Y, false);
                            DrawPlayer(newX, newY);

                            player.X = newX;
                            player.Y = newY;
                            break;

                        case ConsoleKey.Escape: //Exit
                            player.Live--;
                            redraw = true;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Draw Tile at specific X and Y
        /// </summary>
        /// <param name="grid">Draw grid arond tile</param>
        private static void DrawPos(int X, int Y, bool grid = true)
        {
            int x = IsoX(X, Y);
            int y = IsoY(Y);
            switch (map[Y, X])
            {
                case 1:
                    if (grid)
                        DrawTile.Grid(x, y);

                    DrawTile.Ground(x, y);
                    break;

                case 2:
                    if (grid)
                        DrawTile.Grid(x, y);

                    DrawTile.Wall(x, y);
                    break;
            }
        }

        private static void DrawPlayer(int X, int Y)
        {
            DrawTile.Ground(IsoX(X, Y), IsoY(Y), ConsoleColor.Red); //TODO better player
        }

        /// <summary>
        /// Convert Map position to Screen positon
        /// </summary>
        private static int IsoX(int X, int Y)
        {
            return X * 10 + (Y % 2 == 0 ? 0 : 5);
        }

        /// <summary>
        /// Convert Map position to Screen positon
        /// </summary>
        private static int IsoY(int Y)
        {
            return Y * 3;
        }

        /// <summary>
        /// Execute ConsoleKey on X axis
        /// </summary>
        /// <param name="X">Actual player X</param>
        /// <param name="Y">Actual player Y</param>
        /// <returns>New player X</returns>
        private static int MoveX(ConsoleKey K, int X, int Y)
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

        /// <summary>
        /// Execute ConsoleKey on Y axis
        /// </summary>
        /// <param name="Y">Actual player Y</param>
        /// <returns>New player Y</returns>
        private static int MoveY(ConsoleKey K, int Y)
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

        private struct Player
        {
            public int X; //Position on map
            public int Y;
            public int Live;

            public Player(int x, int y, int l)
            {
                X = x;
                Y = y;
                Live = l;
            }
        }
    }
}