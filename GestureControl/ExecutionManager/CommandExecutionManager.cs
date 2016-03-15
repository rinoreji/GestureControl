using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestureControl
{
    public class CommandExecutionManager : IDisposable
    {
        private CommandMappings _command;
        private IExecutable _commandExecuter;
        public CommandExecutionManager(CommandMappings command)
        {
            _command = command;
        }

        public void Execute()
        {
            if (_command.CommandType == CommandType.Process)
                _commandExecuter = new ProcessExecutor();
            else if (_command.CommandType == CommandType.Shortcut)
                _commandExecuter = new ShortcutExecutor();

            if (_commandExecuter.IsNotNull())
                _commandExecuter.Execute(_command.CommandParam);
        }

        public void Dispose()
        {
            _commandExecuter = null;
            _command = null;
        }
    }
}
