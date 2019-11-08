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
        public void CreateAnimal(Animal animal, DatabaseManager manager)
        {
            int Id = animal.getId();
            string Species = animal.getSpecies();
            string Sex = animal.getSex();
            DateTime Birth_date = animal.getBirthDate();
            manager.ExecuteInstruction($"insert into Animals(Id, Species, Sex, Birth_date) values ({Id}, '{Species}', '{Sex}', '{Birth_date.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
        }

        public void DeleteAnimal(Animal animal, DatabaseManager manager)
        {
            int Id = animal.getId();
            string Species = animal.getSpecies();
            string Sex = animal.getSex();
            DateTime Birth_date = animal.getBirthDate();
            manager.ExecuteInstruction($"delete from Animals where Id = {Id}");
        }
    }
}
