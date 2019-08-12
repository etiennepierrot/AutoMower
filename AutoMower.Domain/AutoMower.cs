using System.Collections.Generic;
using System.Linq;

namespace AutoMower.Domain
{
    public class AutoMower
    {
        public string Run(string sequenceChar)
        {
            string[] splittedInput = ReadLines(sequenceChar);
            var lawn = SequenceCharParser.ParseLawn(splittedInput[0]);

            List<PositionMower> positionMowers = new List<PositionMower>();
            for (int indexMower = 0; indexMower < splittedInput.Length / 2; indexMower ++)
            {
                PositionMower positionMower = SequenceCharParser.ParsePosition(splittedInput[2 * indexMower + 1]);
                Command[] commands = SequenceCharParser.ParseCommand(splittedInput[2 * indexMower + 2]);
                positionMower = commands.Aggregate(positionMower, lawn.ApplyCommand);
                positionMowers.Add(positionMower);
            }

            return BuildOutputPosition(positionMowers);
        }

        

        private static string BuildOutputPosition(List<PositionMower> positionMowers)
        {
            return positionMowers.Select(p => p.ToString())
                .Aggregate((current, next) => current + "\r\n" + next);
        }

        private static string[] ReadLines(string inputData)
        {
            return inputData
                .Split("\r\n")
                .Where( str => str != string.Empty)
                .ToArray();
        }

        

        

        
    }
}