using Farm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Farm.Commands
{
    class AddPigCommand : ICommand
    {
        public AddPigCommand(PenViewModel viewModel)
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
            _ViewModel.AddPig();
        }
    }
}
