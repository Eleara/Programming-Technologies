using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Farm.ViewModels;

namespace Farm.Commands
{
    internal class RemoveAllAnimalsCommand : ICommand
    {
        public RemoveAllAnimalsCommand(PenViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        public PenViewModel _ViewModel;

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _ViewModel.RemoveAllAnimals();
        }
    }
}

