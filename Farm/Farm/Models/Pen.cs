using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models {
    public class Pen {
        private List<Animal> animals;

        public Pen() {
            animals = new List<Animal>();
        }

        public void KillAllAnimals() {
            animals.Clear();
        }

        public void AddAnimal(Animal animal) {
            animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal) {
            animals.Remove(animal);
        }
    }
}
