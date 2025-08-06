using System;
using System.Collections.Generic;
using System.Linq;

namespace Wannabuh.Console
{
    public class Console
    {
        public readonly List<string> InputHistory = new();
        private readonly Dictionary<string, ConsoleCommand> _commands = new();
        public Console(GameContext context)
        {
            var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(ConsoleCommand).IsAssignableFrom(t)
                            && !t.IsAbstract
                            && t.GetCustomAttributes(typeof(ConsoleCommandAttribute), false).Length > 0);

            foreach (var type in commandTypes)
            {
                var attr = (ConsoleCommandAttribute)type.GetCustomAttributes(typeof(ConsoleCommandAttribute), false)[0];

                var ctor = type.GetConstructor(new[] { typeof(GameContext) });

                if (ctor == null)
                {
                    continue;
                }

                var instance = (ConsoleCommand)ctor.Invoke(new object[] { context });
                _commands[attr.Name.ToLower()] = instance;
            }
        }

        public void ProcessCommand(string input)
        {
            // Parse the command string
            string[] parts = input.Split(" ");

            if (parts.Length == 0) return;
            
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            if (!_commands.TryGetValue(command, out ConsoleCommand consoleCommand))
            {
                InputHistory.Add($"Unknown Command: {command}");
                return;
            }
            
            consoleCommand.Execute(args);
            InputHistory.Add(input);
        }
    }
}
