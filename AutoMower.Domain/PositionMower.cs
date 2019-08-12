using System;
using System.Linq;

namespace AutoMower.Domain
{
    internal class PositionMower
    {
        public PositionMower(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public override string ToString()
        {
            string charOrientation = SequenceCharParser.OrientationDictionary.Single(kv => kv.Value == Orientation).Key;
            return $"{X} {Y} {charOrientation}";
        }

        public int X { get; }
        public int Y { get; }
        public Orientation Orientation { get; }

        public PositionMower MoveForward(Lawn lawn)
        {
            return lawn.IsInside(PredictPosition()) ? PredictPosition() : this;
        }

        private PositionMower PredictPosition()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new PositionMower(X, Y + 1, Orientation);
                case Orientation.West:
                    return new PositionMower(X - 1, Y, Orientation);
                case Orientation.East:
                    return new PositionMower(X + 1, Y, Orientation);
                case Orientation.South:
                    return new PositionMower(X, Y - 1, Orientation);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public PositionMower RotateToLeft()
        {
            switch (Orientation)
            {
                case Orientation.East:
                    return new PositionMower(X, Y, Orientation.North);
                case Orientation.North:
                    return new PositionMower(X, Y, Orientation.West);
                case Orientation.West:
                    return new PositionMower(X, Y, Orientation.South);
                case Orientation.South:
                    return new PositionMower(X, Y, Orientation.East);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public PositionMower RotateToRight()
        {
            switch (Orientation)
            {
                case Orientation.East:
                    return new PositionMower(X, Y, Orientation.South);
                case Orientation.South:
                    return new PositionMower(X, Y, Orientation.West);
                case Orientation.West:
                    return new PositionMower(X, Y, Orientation.North);
                case Orientation.North:
                    return new PositionMower(X, Y, Orientation.East);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}