using System;
using System.Linq;

namespace AutoMower.Domain
{
    internal class PositionMower
    {
        public PositionMower(int x, int y, Orientation orientation, int idMower)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            IdMower = idMower;
        }

        public override string ToString()
        {
            string charOrientation = SequenceCharParser.OrientationDictionary.Single(kv => kv.Value == Orientation).Key;
            return $"{X} {Y} {charOrientation}";
        }

        public int X { get; }
        public int Y { get; }
        public Orientation Orientation { get; }
        public int IdMower { get; }

        public bool IsSameCoordinate(PositionMower positionMower)
        {
            return positionMower.X == X && positionMower.Y == Y;
        }

        public PositionMower MoveForward(Lawn lawn)
        {
            PositionMower futurePositionMower = PredictPosition();
            return lawn.CanMoveInThisPosition(futurePositionMower) 
                ? futurePositionMower 
                : this;
        }

        private PositionMower PredictPosition()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new PositionMower(X, Y + 1, Orientation, IdMower);
                case Orientation.West:
                    return new PositionMower(X - 1, Y, Orientation, IdMower);
                case Orientation.East:
                    return new PositionMower(X + 1, Y, Orientation, IdMower);
                case Orientation.South:
                    return new PositionMower(X, Y - 1, Orientation, IdMower);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public PositionMower RotateToLeft()
        {
            switch (Orientation)
            {
                case Orientation.East:
                    return new PositionMower(X, Y, Orientation.North, IdMower);
                case Orientation.North:
                    return new PositionMower(X, Y, Orientation.West, IdMower);
                case Orientation.West:
                    return new PositionMower(X, Y, Orientation.South, IdMower);
                case Orientation.South:
                    return new PositionMower(X, Y, Orientation.East, IdMower);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public PositionMower RotateToRight()
        {
            switch (Orientation)
            {
                case Orientation.East:
                    return new PositionMower(X, Y, Orientation.South, IdMower);
                case Orientation.South:
                    return new PositionMower(X, Y, Orientation.West, IdMower);
                case Orientation.West:
                    return new PositionMower(X, Y, Orientation.North, IdMower);
                case Orientation.North:
                    return new PositionMower(X, Y, Orientation.East, IdMower);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}