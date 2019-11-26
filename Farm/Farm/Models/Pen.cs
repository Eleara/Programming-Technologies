using System;
using System.Collections.Generic;
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
        private int chickenCounter = 0;
        private int eventCounter = 0;
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
            sex = new string[2] { "male", "female" };
            random = new Random();
        }

        public void KillAllAnimals() {
            animals.Clear();
        }

        public void AddPig() {
            Pig pig = new Pig(pigCounter, sex[random.Next(0, 1)]);
            pigCounter++;
            aManager.CreateAnimal(cdPig, pig, dbManager);
            makeEvent(eventCounter, pig, "Creation of pig");
        }

        public void AddCow() {
            Cow cow = new Cow(cowCounter, sex[random.Next(0, 1)]);
            cowCounter++;
            aManager.CreateAnimal(cdCow, cow, dbManager);
            makeEvent(eventCounter, cow, "Creation of cow");
        }

        public void AddChicken() {
            Chicken chicken = new Chicken(chickenCounter, sex[random.Next(0, 1)]);
            chickenCounter++;
            aManager.CreateAnimal(cdChicken, chicken, dbManager);
            makeEvent(eventCounter, chicken, "Creation of chicken");
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
            makeEvent(eventCounter, animal, "Deletion of" + animal.GetType());
        }

        public void makeEvent(int id, Animal eventAnimal, string typeOfEvent) {
            Event newEvent = new Event(id, eventAnimal, typeOfEvent);
            eManager.CreateEvent(newEvent, dbManager);
            eventCounter++;
        }

        public void Copulate(Animal animal1, Animal animal2) {
            if (animal1.GetType() == animal2.GetType() && animal1.GetSex() != animal2.GetSex()) {
                if(animal1.GetType() == typeof(Pig)) {
                    AddPig();
                } else if(animal1.GetType() == typeof(Cow)) {
                    AddCow();
                } else {
                    AddChicken();
                }
            }
        }
    }
}
