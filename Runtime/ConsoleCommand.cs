namespace Wannabuh.Console
{
    public abstract class ConsoleCommand
    {
        protected readonly GameContext _context;

        protected ConsoleCommand(GameContext context)
        {
            _context = context;
        }
        
        public abstract string Name { get; }

        public abstract void Execute(string[] args);
    }
}
