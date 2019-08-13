using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMower.Domain
{
    internal class SequenceCharParser
    {
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

        public static Lawn ParseLawn(string dataLawn)
        {
            var splittedDataLawn = dataLawn.Split(' ');
            return new Lawn(Int32.Parse(splittedDataLawn[0]), Int32.Parse(splittedDataLawn[1]));
        }

        public static Dictionary<PositionMower, Command[]> ParseCommandOnMower(string[] splittedInput)
        {
            Dictionary<PositionMower, Command[]> dic = new Dictionary<PositionMower, Command[]>();
            
            for (int indexMower = 0; indexMower < splittedInput.Length / 2; indexMower++)
            {
                PositionMower positionMower = ParsePosition(splittedInput[2 * indexMower + 1]);
                Command[] commands = ParseCommand(splittedInput[2 * indexMower + 2]);
                dic.Add(positionMower, commands);
            }

            return dic;
        }

        private static Command[] ParseCommand(string commandString)
        {
            return commandString.ToCharArray().Select(c => CommandDictionary[c]).ToArray();
        }

        private static PositionMower ParsePosition(string positionString)
        {
            int x = Int32.Parse(positionString.Split(' ')[0]);
            int y = Int32.Parse(positionString.Split(' ')[1]);
            string orientation = positionString.Split(' ')[2];
            return new PositionMower(x, y, OrientationDictionary[orientation]);
        }
    }
}