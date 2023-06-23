using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class CommandManager
    {
        Stack<ICommand> _commands;
        public CommandManager()
        {
            _commands = new Stack<ICommand>();
        }
        public void AddCommand(ICommand command)
        {
            command.Execute();
            _commands.Push(command);
        }
    }
}
