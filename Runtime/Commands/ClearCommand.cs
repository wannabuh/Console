namespace Wannabuh.Console
{
    [ConsoleCommand("clear")]
    public class ClearCommand : ConsoleCommand
    {
        public ClearCommand(GameContext context) : base(context) { }

        public override string Name => "clear";
        
        public override void Execute(string[] args)
        {
            ConsoleBehaviour.Instance.ClearHistory();
        }
    }
}
