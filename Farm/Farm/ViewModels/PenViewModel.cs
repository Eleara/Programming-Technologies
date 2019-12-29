using Farm.Commands;
using Farm.Models;
using System;
using Farm.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace Farm.ViewModels
{
    internal class PenViewModel : INotifyPropertyChanged
    {
        DatabaseManager databaseManager = new DatabaseManager();
        PenManager penManager = new PenManager();
        public PenViewModel()
        {
            _Pen = new Pen("MY PEN");
            penManager.CreatePen(_Pen, databaseManager);
            UpdateCommand = new PenUpdateCommand(this);
        }

        public bool CanUpdate {
            get
            {
                if (Pen == null)
                {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Pen.Name);
            }
        }

        private Pen _Pen;

        public event PropertyChangedEventHandler PropertyChanged;

        public Pen Pen
        {
            get
            {
                return _Pen;
            }
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public void saveChanges()
        {
            if (_Pen.IsValid)
            {
                penManager.UpdatePen(_Pen, databaseManager);
            }
            
        }
    }
}
