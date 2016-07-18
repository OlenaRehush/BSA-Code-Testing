using System;
using System.Windows.Input;

namespace Cashbox.Framework
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        private event EventHandler internalCanExecuteChanged;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                internalCanExecuteChanged += value;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                internalCanExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (_canExecute != null)
            {
                OnCanExecuteChanged();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            var handler = internalCanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
