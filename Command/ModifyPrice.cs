using System.Collections.Generic;
using System.Linq;

namespace Command
{ // Behavioural. To turn a request into an object, which contains all the information about the request. Popular. Especially when wanting to delay or queue a request's execution, or when we want to keep track of our operations. This possibility to keep track of our operations gives us the possibility to undo them as well.
    public class ModifyPrice // the invoker class.
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifyPrice()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }

        public void UndoActions()
        {
            foreach (var command in Enumerable.Reverse(_commands))
            {
                command.UndoAction();
            }
        }
    }
}
