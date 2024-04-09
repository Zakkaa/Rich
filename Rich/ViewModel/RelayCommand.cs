using System;
using System.Windows.Input;

namespace Rich.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> predicate;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Predicate<object> predicate)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }

        public RelayCommand(Action<object> execute)
            : this(execute, _ => { return true; })
        {
        }

        public bool CanExecute(object parameter)
        {
            return predicate != null && predicate(parameter);
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
