using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;

namespace Farm.Managers {
    public class CDCow : ICreateDelete {
        public void Create(Animal animal, DatabaseManager manager) {
            int Id = animal.GetId();
            string Sex = animal.GetSex();
            DateTime Birth_date = animal.GetBirthDate();
            manager.ExecuteInstruction($"insert into Cows(Id, Sex, Birth_date) values ({Id}, '{Sex}', '{Birth_date.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
        }

        public void Delete(Animal animal, DatabaseManager manager) {
            int Id = animal.GetId();
            manager.ExecuteInstruction($"delete from Cows where Id = {Id}");
        }

        public Animal ReadAnimal(int id, DatabaseManager manager) {
            Animal returnAnimal;
            returnAnimal = new Cow(id, manager.RunQuery($"select Sex from Cows where Id = {id}").ToString());
            return returnAnimal;
        }
    }
}
