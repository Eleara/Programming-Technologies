using Farm.Commands;
using Farm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Farm.ViewModels
{
    internal class PenViewModel
    {
        public PenViewModel()
        {
            _Pen = new Pen("MY PEN");
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
            
        }
    }
}
