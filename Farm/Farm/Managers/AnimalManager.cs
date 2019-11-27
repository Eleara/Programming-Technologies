using Farm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Managers
{
    public class AnimalManager
    {

        public void CreateAnimal(ICreateDelete createDelete, Animal animal, DatabaseManager manager) {
            createDelete.Create(animal, manager);
        }

        public void DeleteAnimal(ICreateDelete createDelete, Animal animal, DatabaseManager manager) {
            createDelete.Delete(animal, manager);
        }

        public void DeleteAnimal(ICreateDelete createDelete, int id, DatabaseManager manager) {
            createDelete.Delete(id, manager);
        }

        public Animal ReadAnimal(ICreateDelete createDelete, int id, DatabaseManager manager) {
            return createDelete.ReadAnimal(id, manager);
        }

        public void DeleteAllAnimals(DatabaseManager manager) {
            manager.ExecuteInstruction($"delete from Pigs");
            manager.ExecuteInstruction($"delete from Cows");
            manager.ExecuteInstruction($"delete from Chickens");
        }

        public void DeleteAnimals(ICreateDelete createDelete, DatabaseManager manager) {
            createDelete.DeleteAnimals(manager);
        }

        public int FindId(ICreateDelete createDelete, DatabaseManager manager) {
            return createDelete.FindId(manager);
        }
    }
}
