using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;

namespace Farm.Managers {
    public class CDPig : ICreateDelete {
        public void Create(Animal animal, DatabaseManager manager) {
            int id = animal.GetId();
            string sex = animal.GetSex();
            DateTime birthDate = animal.GetBirthDate();
            manager.ExecuteInstruction($"insert into Pigs(Id, Sex, Birth_date) values ({id}, '{sex}', '{birthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
        }
        public void Delete(Animal animal, DatabaseManager manager) {
            int id = animal.GetId();
            manager.ExecuteInstruction($"delete from Pigs where Id = {id}");
        }

        public Animal ReadAnimal(int id, DatabaseManager manager) {
            Animal returnAnimal;
            returnAnimal = new Pig(id, manager.RunQuery($"select Sex from Pigs where Id = {id}").ToString());
            return returnAnimal;
        }
    }
}
