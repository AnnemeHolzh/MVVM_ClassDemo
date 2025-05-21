using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_ClassDemo.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> _Execute {  get; set; }
        private Predicate<object> _CanExecute { get; set; } //A method that returns a boolean

        public RelayCommand(Action<object> ExecuteMethod, Predicate<object> CanExecuteMethod) // <- References to a method 
        { 
            _Execute = ExecuteMethod;
            _CanExecute = CanExecuteMethod;
        }

        public bool CanExecute(object? parameter) // <- The paramater comes from the command called from the UI. 
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter); //Executing the method/command the user provided. 
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
