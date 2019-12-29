using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Managers;

namespace Farm.Models {
    public class Pen : IDataErrorInfo, INotifyPropertyChanged
    {
        private List<Animal> animals;
        private AnimalManager aManager;
        private DatabaseManager dbManager;
        private EventManager eManager;
        private CDPig cdPig;
        private CDCow cdCow;
        private CDChicken cdChicken;
        private int size;
        private int maxSize = 25;
        private string[] sex;
        private Random random;
        private string _Name;

        public Pen(string penName) {
            animals = new List<Animal>();
            aManager = new AnimalManager();
            dbManager = new DatabaseManager();
            eManager = new EventManager();
            cdPig = new CDPig(); 
            cdCow = new CDCow();
            cdChicken = new CDChicken();
            sex = new string[2] { "M", "F" };
            random = new Random();
            size = 25;
            FillList();
            Name = penName;    
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }

        public Animal GetAnimal(int position) {
            return animals[position];
        }

        public bool canFit() {
            if (animals.Count + 1 >= size) return false;
            else return true;
        }

        public void KillAllAnimals() {
            animals.Clear();
            aManager.DeleteAllAnimals(dbManager);
        }

        public void AddPig() {
            if (canFit()) {
                Pig pig = new Pig(aManager.FindId(cdPig, dbManager), sex[random.Next(0, 2)]);
                aManager.CreateAnimal(cdPig, pig, dbManager);
                animals.Add(pig);
                MakeEvent(pig, "Creation of pig");
            }
            else {
                Console.WriteLine("There is no place for another animal!");
            }
        }

        public void AddCow() {
            if(canFit()) {
                Cow cow = new Cow(aManager.FindId(cdCow, dbManager), sex[random.Next(0, 2)]);
                aManager.CreateAnimal(cdCow, cow, dbManager);
                animals.Add(cow);
                MakeEvent(cow, "Creation of cow");
            }
            else {
                Console.WriteLine("There is no place for another animal!");
            }
        }

        public void AddChicken() {
            if (canFit()) {
                Chicken chicken = new Chicken(aManager.FindId(cdChicken, dbManager), sex[random.Next(0, 2)]);
                aManager.CreateAnimal(cdChicken, chicken, dbManager);
                animals.Add(chicken);
                MakeEvent(chicken, "Creation of chicken");
            }
            else {
                Console.WriteLine("There is no place for another animal!");
            }
        }

        public void RemoveAnimal(Animal animal) {
            animals.Remove(animal);
            if(animal.GetType() == typeof(Pig)) {
                aManager.DeleteAnimal(cdPig, animal, dbManager);
            } else if(animal.GetType() == typeof(Cow)) {
                aManager.DeleteAnimal(cdCow, animal, dbManager);
            } else {
                aManager.DeleteAnimal(cdChicken, animal, dbManager);
            }
            MakeEvent(animal, "Deletion of" + animal.GetType());
        }

        public void MakeEvent(Animal eventAnimal, string typeOfEvent) {
            Event newEvent = new Event(eManager.FindId(dbManager), eventAnimal, typeOfEvent);
            eManager.CreateEvent(newEvent, dbManager);
            Console.WriteLine("chuj");
        }

        public bool Copulate(Animal animal1, Animal animal2) {
            if (canFit() && animal1.GetType() == animal2.GetType() && animal1.GetSex() != animal2.GetSex()) {
                if (animal1.GetType() == typeof(Pig)) {
                    AddPig();
                }
                else if (animal1.GetType() == typeof(Cow)) {
                    AddCow();
                }
                else {
                    AddChicken();
                }
                MakeEvent(animal1, "Copulation of a" + animal1.GetType().ToString() + animal1.GetId());
                MakeEvent(animal2, "Copulation of a" + animal2.GetType().ToString() + animal2.GetId());
                Console.WriteLine("copulate");
                return true;
            }
            else {
                Console.WriteLine("You cannot copulate those two animals!");
                return false;
            }
        }
        public void FillList()
        {
            DataTable outcomePigs = dbManager.RunQuery("select * from Pigs");
            DataTable sizePigs = dbManager.RunQuery("select count(Id) as s from Pigs");
            int amountPigs = Convert.ToInt32(sizePigs.Rows[0]["s"]);
            for (int i = 0; i < amountPigs; i++)
            {
                animals.Add(aManager.ReadAnimal(cdPig, Convert.ToInt32(outcomePigs.Rows[i]["Id"]),
                    dbManager));
            }
            DataTable outcomeCows = dbManager.RunQuery("select * from Cows");
            DataTable sizeCows = dbManager.RunQuery("select count(Id) as s from Cows");
            int amountCows = Convert.ToInt32(sizeCows.Rows[0]["s"]);
            for (int i = 0; i < amountCows; i++)
            {
                animals.Add(aManager.ReadAnimal(cdCow, Convert.ToInt32(outcomeCows.Rows[i]["Id"]),
                    dbManager));
            }

            DataTable outcomeChickens = dbManager.RunQuery("select * from Chickens");
            DataTable sizeChickens = dbManager.RunQuery("select count(Id) as s from Chickens");
            int amountChickens = Convert.ToInt32(sizeChickens.Rows[0]["s"]);
            for (int i = 0; i < amountChickens; i++)
            {
                animals.Add(aManager.ReadAnimal(cdChicken, Convert.ToInt32(outcomeChickens.Rows[i]["Id"]),
                    dbManager));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }

        }

        static readonly string[] ValidatedProperties =
        {
            "Name"
        };

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        private string ValidateName()
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                return "Pen name cannot be empty.";
            }

            else if (Name.Length > 20)
            {
                return "Pen name cannot be longer than 20 characters.";
            }

            return null;
        }

        string GetValidationError(String propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Name":
                    error = ValidateName();
                    break;


            }
            return error;
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return true;
            }
        }



    }
}
