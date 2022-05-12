using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Raylibtest
{
    public class LeftRec
    {

        public static int X = 50;
        public static int Y = Raylib.GetScreenHeight() / 2 - 50;
        public static int Width = 10;
        public static int Height = 100;
        public static int Speed = 300;

        public static void Draw()
        {
            Raylib.DrawRectangle(X, Y, Width, Height, Color.WHITE);
        }

        public static void Move()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                Y -= 5;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                Y += 5;
            }
        }
        public static void OutOfMapLeft()
        {
            if (Y > Raylib.GetScreenHeight() - Height)
            {
                Y = Raylib.GetScreenHeight() - Height;
            }
            if (Y < 0)
            {
                Y = 0;
            }
        }

        internal static Rectangle RectangleLeft(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

    }
}
