using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Занятие19WpfApp1
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        public readonly Func<object, bool> canExecut;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecut = CanExecute;
        }


        public bool CanExecute(object parameter) => canExecut?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => execute(parameter);
    }
}
