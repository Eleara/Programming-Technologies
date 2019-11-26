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
        /*public void CreateAnimal(Animal animal, DatabaseManager manager)
        {
            int Id = animal.GetId();
            string Sex = animal.GetSex();
            DateTime Birth_date = animal.GetBirthDate();
            if (animal.GetType() == typeof(Pig))
            {
                manager.ExecuteInstruction($"insert into Pigs(Id, Sex, Birth_date) values ({Id}, '{Sex}', '{Birth_date.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
            }
            else if (animal.GetType() == typeof(Cow))
            {
                manager.ExecuteInstruction($"insert into Cows(Id, Sex, Birth_date) values ({Id}, '{Sex}', '{Birth_date.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
            }
            else if (animal.GetType() == typeof(Chicken))
            {
                manager.ExecuteInstruction($"insert into Chickens(Id, Sex, Birth_date) values ({Id}, '{Sex}', '{Birth_date.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
            }

        }*/

        public void CreateAnimal(ICreateDelete createDelete, Animal animal, DatabaseManager manager) {
            createDelete.Create(animal, manager);
        }

        /*public void DeleteAnimal(Animal animal, DatabaseManager manager)
        {
            int Id = animal.GetId();
            if (animal.GetType() == typeof(Pig))
            {
                manager.ExecuteInstruction($"delete from Pigs where Id = {Id}");
            }
            else if (animal.GetType() == typeof(Cow))
            {
                manager.ExecuteInstruction($"delete from Cows where Id = {Id}");
            }
            else if (animal.GetType() == typeof(Chicken))
            {
                manager.ExecuteInstruction($"delete from Chickens where Id = {Id}");
            }
        }*/

        public void DeleteAnimal(ICreateDelete createDelete, Animal animal, DatabaseManager manager) {
            createDelete.Delete(animal, manager);
        }
    }
}
