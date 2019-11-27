using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;

namespace Farm.Managers {
    public interface ICreateDelete {
        void Create(Animal animal, DatabaseManager manager);
        void Delete(Animal animal, DatabaseManager manager);
        void Delete(int id, DatabaseManager manager);
        void DeleteAnimals(DatabaseManager manager);
        Animal ReadAnimal(int id, DatabaseManager manager);
        int FindId(DatabaseManager manager);
    }
}
