using System;
using Farm.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Farm.Commands
{
    internal class AddAnimalCommand : ICommand {

        private int option;

        public AddAnimalCommand(PenViewModel viewModel, int option) {
            _ViewModel = viewModel;
            this.option = option;
        }

        private PenViewModel _ViewModel;

        public event System.EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object parameter) {
            if(option == 0) {
                _ViewModel.AddChicken();
            } else if(option == 1) {
                _ViewModel.AddPig();
            } else {
                _ViewModel.AddCow();
            }
            _ViewModel.saveChanges();
        }
    }
}
