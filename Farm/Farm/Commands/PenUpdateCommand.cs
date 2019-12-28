using Farm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Farm.Commands
{
    internal class PenUpdateCommand : ICommand
    {
        public PenUpdateCommand(PenViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        private PenViewModel _ViewModel;

        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ViewModel.saveChanges();
        }
    }
}
