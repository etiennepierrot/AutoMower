using System.IO;

namespace AutoMower.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            string content = File.ReadAllText(path);

            System.Console.WriteLine("input file ");
            System.Console.WriteLine(content);

            string result = new Domain.AutoMower().Run(content);

            System.Console.WriteLine("result ");
            System.Console.WriteLine(result);

            System.Console.WriteLine("Press a key to exit.");
            System.Console.ReadKey();
        }
    }
}
