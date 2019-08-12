using System;

namespace AutoMower.Domain
{
    internal class Lawn
    {
        public Lawn(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public PositionMower ApplyCommand(PositionMower position, Command command)
        {
            switch (command)
            {
                case Command.Left:
                    return position.RotateToLeft();
                case Command.Right:
                    return position.RotateToRight();
                case Command.Forward:
                    return position.MoveForward(this);
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, null);
            }
        }

        public int Width { get; }
        public int Height { get; }

        public bool IsInside(PositionMower futurePosition)
        {
            return futurePosition.X >= 0 
                   && futurePosition.X <= Width 
                   && futurePosition.Y >= 0
                   && futurePosition.Y <= Height;

        }
    }
}