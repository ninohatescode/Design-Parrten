using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Command
{
    public class Invoker
    {
        private ICommand _command;

        public Invoker() { }

        public void SetCommand(ICommand command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }


    }
}