using CommandLine;
namespace DataGenerator
{
    public class Options
    {
        [Option('t', "total", Required = true, HelpText = "Total of register to be genereate")]
        public int Total { get; set; }
    }
}