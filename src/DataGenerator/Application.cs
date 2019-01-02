using System.Threading.Tasks;
using CommandLine;

namespace DataGenerator
{
    public static class Application
    {
        public static void Main(string[] args)
        {
            var generateData = new GenerateData();
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(async option =>
            {
                if (option.Total == 0) return;
                System.Console.WriteLine("Waiting...");
                for (int i = 1; i <= option.Total; i++)
                {
                    await generateData.Add(Helper.RandomEnumValue<Country>());
                    System.Console.Write(".");
                }
                System.Console.WriteLine("\nFinish!");
            });
            generateData.GenerateFile();
        }
    }
}