using UnityEngine;

namespace Wannabuh.Console
{
    [ConsoleCommand(CommandName)]
    public class TestCommand : ConsoleCommand
    {
        private const string CommandName = "test_command";
        
        public TestCommand(GameContext context) : base(context) { }

        public override string Name => CommandName;
        
        public override void Execute(string[] args)
        {
            Debug.Log("This is a test command.");
        }
    }
}
