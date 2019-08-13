using System.Collections.Generic;
using System.Linq;

namespace AutoMower.Domain
{
    public class AutoMower
    {
        public string Run(string sequenceChar)
        {
            string[] splittedInput = ReadLines(sequenceChar);
            Dictionary<PositionMower, Command[]> commandsOnMowers = SequenceCharParser.ParseCommandOnMower(splittedInput);

            Lawn lawn = SequenceCharParser.ParseLawn(splittedInput[0], commandsOnMowers.Keys.ToArray());

            IEnumerable<PositionMower> newPositionMowers = ApplyCommands(commandsOnMowers, lawn);
            return BuildOutputPosition(newPositionMowers);
        }

        private static IEnumerable<PositionMower> ApplyCommands(Dictionary<PositionMower, Command[]> commandsOnMowers, Lawn lawn)
        {
            foreach (PositionMower positionMower in commandsOnMowers.Keys)
            {
                yield return commandsOnMowers[positionMower].Aggregate(positionMower, lawn.ApplyCommand);
            }
        }


        private static string BuildOutputPosition(IEnumerable<PositionMower> positionMowers)
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