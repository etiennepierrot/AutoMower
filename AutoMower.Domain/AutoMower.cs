using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMower.Domain
{
    public class AutoMower
    {
        public string Run(string inputData)
        {
            string[] splittedInput = inputData.Split("\r\n");
            string positionString = splittedInput[1];
            PositionMower positionMower = ParsePosition(positionString);
            positionMower = ParseCommand(splittedInput[2]).Aggregate(positionMower, ApplyCommand);
            return positionMower.ToString();
        }

        internal static readonly Dictionary<string, Orientation> OrientationDictionary = new Dictionary<string, Orientation>()
        {
            {"N", Orientation.North},
            {"W", Orientation.West},
            {"E", Orientation.East},
            {"S", Orientation.South},
        };

        private static readonly Dictionary<char, Command> CommandDictionary = new Dictionary<char, Command>()
        {
            {'L', Command.Left},
            {'R', Command.Right},
            {'F', Command.Forward}
        };

        private Command[] ParseCommand(string commandString)
        {
            return commandString.ToCharArray().Select(c => CommandDictionary[c]).ToArray();
        }

        private PositionMower ApplyCommand(PositionMower position, Command command)
        {
            switch (command)
            {
                case Command.Left:
                    return position.RotateToLeft();
                case Command.Right:
                    return position.RotateToRight();
                case Command.Forward:
                    return position.MoveForward();
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, null);
            }
        }


        private static PositionMower ParsePosition(string positionString)
        {
            int x = int.Parse(positionString.Split(' ')[0]);
            int y = int.Parse(positionString.Split(' ')[1]);
            string orientation = positionString.Split(' ')[2];
            return new PositionMower(x, y, OrientationDictionary[orientation]);
        }
    }
}