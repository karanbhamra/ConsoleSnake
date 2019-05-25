using System;
using System.Numerics;

namespace TerminalSnake
{
    public class Food
    {
        public Vector2 Pos { get; set; }

        public Food(Vector2 pos)
        {
            Pos = pos;
        }

        public void NewLocation(Vector2 newloc)
        {
            Pos = newloc;
        }
        public void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition((int) Pos.X, (int) Pos.Y);
            Console.Write("F");
        }
    }
}