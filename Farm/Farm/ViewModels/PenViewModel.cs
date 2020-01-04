﻿using Farm.Commands;
using Farm.Models;
using System;
using Farm.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Presentation.ViewModel;

namespace Farm.ViewModels
{
    internal class PenViewModel : ViewModelBase
    {
        DatabaseManager databaseManager = new DatabaseManager();
        PenManager penManager = new PenManager();
        public PenViewModel()
        {
            _Pen = new Pen("MY PEN");
            penManager.CreatePen(_Pen, databaseManager);
            _animals = new List<Animal>();
            _animals = _Pen.GetAnimals();
            UpdateCommand = new PenUpdateCommand(this);
            AddChickenCommand = new AddAnimalCommand(this, 0); //0 for chicken, 1 for pig and 2 for cow
            AddPigCommand = new AddAnimalCommand(this, 1);
            AddCowCommand = new AddAnimalCommand(this, 2);
            RemoveAnimalCommand = new RemoveAnimalCommand(this);
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

        //public event PropertyChangedEventHandler PropertyChanged;

        public Pen Pen
        {
            get
            {
                return _Pen;
            }
        }

        private Animal _selectedAnimal;
        public Animal SelectedAnimal {
            get {
                return _selectedAnimal;
            }
            set {
                _selectedAnimal = value;
                RaisePropertyChanged("Selected Animal");
            }
        }

        /*public String Species {
            get {
                return _selectedAnimal.GetType().ToString();
            }
            set {
                RaisePropertyChanged("Species changed");
            }
        }*/

        private IEnumerable<Animal> _animals;
        public IEnumerable<Animal> Animals {
            get {
                return _animals;
            }
            set {
                _animals = value;
                RaisePropertyChanged("Animals");
            }
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public ICommand AddChickenCommand {
            get;
            private set;
        }

        public ICommand AddPigCommand {
            get;
            private set;
        }

        public ICommand AddCowCommand {
            get;
            private set;
        }

        public ICommand RemoveAnimalCommand {
            get;
            private set;
        }

        public void AddChicken() {
            if (_Pen.IsValid) {
                _Pen.AddChicken();
            }
        }

        public void AddPig() {
            if (_Pen.IsValid) {
                _Pen.AddPig();
            }
        }

        public void AddCow() {
            if (_Pen.IsValid) {
                _Pen.AddCow();
            }
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
