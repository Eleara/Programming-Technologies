using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;
using System.Data;

namespace Farm.Managers {
    public class CDCow : ICreateDelete {
        public void Create(Animal animal, DatabaseManager manager) {
            int id = animal.GetId();
            string sex = animal.GetSex();
            int levelOfFood = animal.GetLevelOfFood();
            int lifeLength = animal.GetLifeLength();
            DateTime birthDate = animal.GetBirthDate();
            manager.ExecuteInstruction($"insert into Cows(Id, Sex, Birth_date, Level_of_food, Life_length) values ({id}, '{sex}', '{birthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', {levelOfFood}, {lifeLength})");
        }

        public void Delete(Animal animal, DatabaseManager manager) {
            int id = animal.GetId();
            manager.ExecuteInstruction($"delete from Cows where Id = {id}");
        }

        public void Delete(int id, DatabaseManager manager) {
            manager.ExecuteInstruction($"delete from Cows where Id = {id}");
        }

        public void DeleteAnimals(DatabaseManager manager) {
            manager.ExecuteInstruction($"delete from Cows");
        }

        public Animal ReadAnimal(int id, DatabaseManager manager) {
            Animal returnAnimal;
            DataTable outcomeCows = manager.RunQuery($"select * from Cows where Id = {id}");
            returnAnimal = new Cow(id, outcomeCows.Rows[0]["Sex"].ToString(),
                                       Convert.ToInt32(outcomeCows.Rows[0]["Life_length"]),
                                       Convert.ToInt32(outcomeCows.Rows[0]["Level_of_food"]),
                                       Convert.ToDateTime(outcomeCows.Rows[0]["Birth_date"]));
            return returnAnimal;
        }

        public int FindId(DatabaseManager manager) {
            int returnId = 0;
            DataTable outcomeId = manager.RunQuery($"select MAX(Id) as m from Cows");
            if(outcomeId.Rows[0]["m"] != DBNull.Value) {
                returnId = Convert.ToInt32(outcomeId.Rows[0]["m"]) + 1;
            }
            return returnId;
        }
    }
}
