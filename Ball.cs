using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

namespace Raylibtest
{

    public class Ball
    {
        public static float X = Raylib.GetScreenWidth() / 2;
        public static float Y = Raylib.GetScreenHeight() / 2;
        public static float Radius = 5.0f;
        public static float SpeedX = 200.0f;
        public static float SpeedY = 200.0f;
        public static string WinnerText = null;


        public static void BallDraw()
        {
            Raylib.DrawCircle((int)Ball.X, (int)Ball.Y, Ball.Radius, Color.WHITE);

        }
        public static float BallMovingX()
        {
            return X += SpeedX * Raylib.GetFrameTime();
        }
        public static float BallMovingY()
        {
            return Y -= SpeedY * Raylib.GetFrameTime();
        }
        public static float BallColdieY()
        {
            if (Y < 0)
            {
                Y = 0;
                SpeedY *= -1;
            }
            if (Y > Raylib.GetScreenHeight())
            {
                Y = Raylib.GetScreenHeight();
                return SpeedY *= -1;
            }
            return SpeedY;
        }
        public static bool BallColideRectengle()
        {
            if (Raylib.CheckCollisionCircleRec(Vector2(X, Y), Radius, LeftRec.RectangleLeft(LeftRec.X, LeftRec.Y, LeftRec.Width, LeftRec.Height)))
            {
                if (SpeedX < 0)
                {
                    SpeedX *= -1.1f;
                    return true;
                    //SpeedY = (Y - LeftRec.Y) / (LeftRec.Width / 2) * SpeedX;

                }
            }
            if (Raylib.CheckCollisionCircleRec(Vector2(X, Y), Radius, RightRec.RectangleRight(RightRec.X, RightRec.Y, RightRec.Width, RightRec.Height)))
            //X > RightRec.X && Y > RightRec.Y - Radius * 2 && Y < RightRec.Y + RightRec.Height
            {
                if (SpeedX > 0)
                {
                    SpeedX *= -1.1f;
                    return true;
                    // = (Y - RightRec.Y) / (RightRec.Width / 2) * SpeedX;
                }
            }
            return false;
        }

        private static Vector2 Vector2(float x, float y)
        {
            return new Vector2(x, y);
        }

        public static void WinnerCheck()
        {
            if (X < 0)
            {
                WinnerText = "Right player wins!";

            }
            if (X > Raylib.GetScreenWidth())
            {
                WinnerText = "Left player wins!";
            }

        }
        public static float BallColideX()
        {
            if (X < 0)
            {
                X = 0;
                SpeedX *= -1;
            }
            if (X > Raylib.GetScreenWidth())
            {
                X = Raylib.GetScreenWidth();
                return SpeedX *= -1;
            }
            return SpeedX;
        }//no need just for exercsise
    }
}
