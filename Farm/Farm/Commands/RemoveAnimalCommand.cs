using System;
using Farm.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Farm.Commands
{
    internal class RemoveAnimalCommand : ICommand {

        public RemoveAnimalCommand(PenViewModel viewModel) {
            _ViewModel = viewModel;
        }

        public PenViewModel _ViewModel;

        public event System.EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object parameter) {
            //_ViewModel.removeAnimal();
        }
    }
}
