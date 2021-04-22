using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

namespace Sample.AzureSearchLoadTests
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            var main = new RootCommand
            {
                CreateRunCommand()
            };

            await main.InvokeAsync(args);
        }

        private static Command CreateRunCommand()
            => new Command("run", "Run AZURE Search load test")
            {
                new Option<string>(
                    new string[]{ "--apiKey", "-k"},
                    "Api key for AZURE Search."),
                new Option<string>(
                    new [] { "--prefix", "-p"},
                    "AZURE Resources prefix."),
                new Option<int>(
                    new [] { "--iterationCount", "-i"},
                    () => 100,
                    "How many requests to send to search.")
            }.WithHandler(CommandHandler.Create<string, string, int>(LoadTest.RunAsync));
    }
}
