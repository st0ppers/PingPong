using Raylib_cs;
using Raylibtest;
namespace HelloWorld
{

    static class Program
    {
        public static void Main()
        {
            int Timer = 501;
            Raylib.InitWindow(800, 600, "Hello World");
            Raylib.SetWindowState(ConfigFlags.FLAG_VSYNC_HINT); //creating vsync (fps for your monitors max hrz)

            while (!Raylib.WindowShouldClose())
            {
                Ball.BallMovingX();
                Ball.BallMovingY();

                Ball.BallColdieY();
                Ball.BallColideRectengle();

                Ball.WinnerCheck();

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawFPS(0, 0);



                Ball.BallDraw();
                LeftRec.Draw();
                LeftRec.Move();
                RightRec.Draw();
                RightRec.Move();
                RightRec.OutOfMapRight();
                LeftRec.OutOfMapLeft();


                if (Ball.WinnerText != null)
                {
                    int TimerWidth = Raylib.MeasureText("5", 60);
                    int WinnerTextWidth = Raylib.MeasureText(Ball.WinnerText, 60);
                    Raylib.DrawText(Ball.WinnerText, Raylib.GetScreenWidth() / 2 - WinnerTextWidth / 2, Raylib.GetScreenWidth() / 2 - 30, 60, Color.YELLOW);
                    if (Timer > 0)
                    {
                        Timer--;
                        Raylib.DrawText("Game will rest in:", Raylib.GetScreenWidth() / 2 - WinnerTextWidth / 2, 170, 60, Color.YELLOW);
                        Raylib.DrawText(((Timer / 100) + 1).ToString(), Raylib.GetScreenWidth() / 2 - TimerWidth / 2, Raylib.GetScreenHeight() / 2 - 30, 60, Color.YELLOW);
                        if (Timer == 0)
                        {
                            Ball.X = Raylib.GetScreenWidth() / 2;
                            Ball.Y = Raylib.GetScreenHeight() / 2;
                            Ball.SpeedX = 300;
                            Ball.SpeedY = 300;
                            Ball.WinnerText = null;
                            Timer = 500;
                        }
                    }
                }
                if (Ball.WinnerText != null && Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                {
                    Ball.X = Raylib.GetScreenWidth() / 2;
                    Ball.Y = Raylib.GetScreenHeight() / 2;
                    Ball.SpeedX = 300;
                    Ball.SpeedY = 300;
                    Ball.WinnerText = null;
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}