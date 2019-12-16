using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;
using System.Data;

namespace Farm.Managers {
    public class CDPig : ICreateDelete {

        public void Create(Animal animal, DatabaseManager manager) {
            int id = animal.GetId();
            string sex = animal.GetSex();
            int levelOfFood = animal.GetLevelOfFood();
            int lifeLength = animal.GetLifeLength();
            DateTime birthDate = animal.GetBirthDate();
            manager.ExecuteInstruction($"insert into Pigs(Id, Sex, Birth_date, Level_of_food, Life_length) values ({id}, '{sex}', '{birthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', {levelOfFood}, {lifeLength})");
        }
        public void Delete(Animal animal, DatabaseManager manager) {
            int id = animal.GetId();
            manager.ExecuteInstruction($"delete from Pigs where Id = {id}");
        }

        public void Delete(int id, DatabaseManager manager) {
            manager.ExecuteInstruction($"delete from Pigs where Id = {id}");
        }

        public void DeleteAnimals(DatabaseManager manager) {
            manager.ExecuteInstruction($"delete from Pigs");
        }

        public Animal ReadAnimal(int id, DatabaseManager manager) {

            Animal returnAnimal;
            DataTable outcomePigs = manager.RunQuery($"select * from Pigs where Id = {id}");

            returnAnimal = new Pig(id, outcomePigs.Rows[0]["Sex"].ToString(),
                                       Convert.ToInt32(outcomePigs.Rows[0]["Life_length"]),
                                       Convert.ToInt32(outcomePigs.Rows[0]["Level_of_food"]),
                                       Convert.ToDateTime(outcomePigs.Rows[0]["Birth_date"]));
            return returnAnimal;
        }

        public int FindId(DatabaseManager manager) {
            int returnId = 0;
            DataTable outcomeId = manager.RunQuery($"select MAX(Id) as m from Pigs");
            if (outcomeId.Rows[0]["m"] != DBNull.Value) {
                returnId = Convert.ToInt32(outcomeId.Rows[0]["m"]) + 1;
            }
            return returnId;
        }
    }
}
