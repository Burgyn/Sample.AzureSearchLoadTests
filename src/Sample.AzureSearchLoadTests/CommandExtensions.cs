using System.CommandLine;
using System.CommandLine.Invocation;

namespace Sample.AzureSearchLoadTests
{
    internal static class CommandExtensions
    {
        public static Command WithHandler(this Command command, ICommandHandler commandHandler)
        {
            command.Handler = commandHandler;

            return command;
        }
    }
}
