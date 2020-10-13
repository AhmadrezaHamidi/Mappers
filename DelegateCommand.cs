using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BookAndShelve
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Predicate<object> canExecute;
        Action<object> execute;
        public DelegateCommand(Predicate<object> _canexecute, Action<object> _execute) : this()
        {
            canExecute = _canexecute;
            execute = _execute;
        }

        public DelegateCommand(Action<object> _execute) : this(null, _execute)
        { }

        public DelegateCommand()
        { }
        
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }
        
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
