using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Managers;

namespace Farm.Models {
    public class Pen {
        private List<Animal> animals;
        private AnimalManager aManager;
        private DatabaseManager dbManager;
        private EventManager eManager;
        private CDPig cdPig;
        private CDCow cdCow;
        private CDChicken cdChicken;
        private int pigCounter = 0;
        private int cowCounter = 0;
        private int chickenCounter;
        private int eventCounter;
        private string[] sex;
        private Random random;

        public Pen() {
            animals = new List<Animal>();
            aManager = new AnimalManager();
            dbManager = new DatabaseManager();
            eManager = new EventManager();
            cdPig = new CDPig(); 
            cdCow = new CDCow();
            cdChicken = new CDChicken();
            sex = new string[2] { "M", "F" };
            random = new Random();
            chickenCounter = 0;
            eventCounter = 0;
            FillList();
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }

        public Animal GetAnimal(int position) {
            return animals[position];
        }

        public void KillAllAnimals() {
            animals.Clear();
            aManager.DeleteAllAnimals(dbManager);
        }

        public void AddPig() {
            Pig pig = new Pig(pigCounter, sex[random.Next(0, 1)]);
            pigCounter++;
            aManager.CreateAnimal(cdPig, pig, dbManager);
            animals.Add(pig);
            MakeEvent(eventCounter, pig, "Creation of pig");
        }

        public void AddCow() {
            Cow cow = new Cow(cowCounter, sex[random.Next(0, 1)]);
            cowCounter++;
            aManager.CreateAnimal(cdCow, cow, dbManager);
            animals.Add(cow);
            MakeEvent(eventCounter, cow, "Creation of cow");
        }

        public void AddChicken() {
            Chicken chicken = new Chicken(chickenCounter, sex[random.Next(0, 1)]);
            chickenCounter++;
            aManager.CreateAnimal(cdChicken, chicken, dbManager);
            animals.Add(chicken);
            MakeEvent(eventCounter, chicken, "Creation of chicken");
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
            MakeEvent(eventCounter, animal, "Deletion of" + animal.GetType());
        }

        public void MakeEvent(int id, Animal eventAnimal, string typeOfEvent) {
            Event newEvent = new Event(id, eventAnimal, typeOfEvent);
            eManager.CreateEvent(newEvent, dbManager);
            eventCounter++;
        }

        public bool Copulate(Animal animal1, Animal animal2) {
            if (animal1.GetType() == animal2.GetType() && animal1.GetSex() != animal2.GetSex()) {
                if (animal1.GetType() == typeof(Pig)) {
                    AddPig();
                }
                else if (animal1.GetType() == typeof(Cow)) {
                    AddCow();
                }
                else {
                    AddChicken();
                }
                MakeEvent(eventCounter, animal1, "Copulation of a" + animal1.GetType().ToString() + animal1.GetId());
                MakeEvent(eventCounter, animal2, "Copulation of a" + animal2.GetType().ToString() + animal2.GetId());
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

        

    }
}
