using System;
using System.Linq;

namespace AutoMower.Domain
{
    internal class Lawn
    {
        public Lawn(int width, int height, PositionMower[] positionMowers)
        {
            _width = width;
            _height = height;
            _positionMowers = positionMowers;
        }

        private readonly PositionMower[] _positionMowers;
        private readonly int _width;
        private readonly int _height;

        public PositionMower ApplyCommand(PositionMower position, Command command)
        {
            PositionMower positionMower;
            switch (command)
            {
                case Command.Left:
                    positionMower = position.RotateToLeft();
                    break;
                case Command.Right:
                    positionMower = position.RotateToRight();
                    break;
                case Command.Forward:
                    positionMower = position.MoveForward(this);
                    break; ;
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, null);
            }

            Track(positionMower);
            return positionMower;
        }

        private void Track(PositionMower positionMower)
        {
            _positionMowers[positionMower.IdMower] = positionMower;
        }

        public bool CanMoveInThisPosition(PositionMower futurePositionMower)
        {
            return Contains(futurePositionMower) 
                   && !AnotherMowerInThisPosition(futurePositionMower);
        }

        private bool AnotherMowerInThisPosition(PositionMower positionMower)
        {
            return _positionMowers.Any(p => 
                       p.IdMower != positionMower.IdMower
                    && p.IsSameCoordinate(positionMower));
        }

        private bool Contains(PositionMower futurePosition)
        {
            return futurePosition.X >= 0 
                   && futurePosition.X <= _width 
                   && futurePosition.Y >= 0
                   && futurePosition.Y <= _height;

        }
    }
}