using System;

namespace Wannabuh.Console
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConsoleCommandAttribute : Attribute
    {
        public string Name { get; }

        public ConsoleCommandAttribute(string name)
        {
            Name = name;
        }
    }
}
