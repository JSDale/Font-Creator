using System.Windows.Input;

namespace FontCreator
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        private readonly Predicate<object>? _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            //// Intentionally blank
        }

#pragma warning disable IDE0290 // Use primary constructor, it confuses my simple mind...
        public RelayCommand(Action<object> execute, Predicate<object>? canExecute)
#pragma warning restore IDE0290 // Use primary constructor
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this._canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<inheritdoc cref="ICommand.CanExecute"/>
        public bool CanExecute(object? parameter)
        {
            return this._canExecute?.Invoke(parameter!) ?? true;
        }

        ///<inheritdoc cref="ICommand.Execute"/>
        public void Execute(object? parameter)
        {
            this._execute(parameter!);
        }
    }
}
