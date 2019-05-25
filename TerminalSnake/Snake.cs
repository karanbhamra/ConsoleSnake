using System;
using System.Numerics;

namespace TerminalSnake
{
    public enum Direction
    {
        None,
        Top,
        Down,
        Left,
        Right
    }

    public class Snake
    {
        public Vector2 Pos { get; set; }

        public string DisplayChar { get;  set; }
        public Direction CurrentDirection { get; private set; }

        public bool IsAlive { get; private set; }

        public Snake(Vector2 pos, string displayChar)
        {
            Pos = pos;
            CurrentDirection = Direction.Right;
            IsAlive = true;
            DisplayChar = displayChar;
        }

        public void UpdateDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    CurrentDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    CurrentDirection = Direction.Top;
                    break;
                case ConsoleKey.DownArrow:
                    CurrentDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    CurrentDirection = Direction.Left;
                    break;
            }
        }

        public void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.Top:
                    Pos += new Vector2(0, -1);
                    break;
                case Direction.Down:
                    Pos += new Vector2(0, 1);
                    break;
                case Direction.Left:
                    Pos += new Vector2(-1, 0);
                    break;
                case Direction.Right:
                    Pos += new Vector2(1, 0);
                    break;
            }

        }

        public void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition((int) Pos.X, (int) Pos.Y);
            Console.Write(DisplayChar);
        }

        public void BoundsCheck(int width, int height)//, Food food)
        {
            if (Pos.X >= width || Pos.X <= 0 || Pos.Y <= 0 || Pos.Y >= height)
            {
                IsAlive = false;
            }

        }
    }
}