using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Animal
    {
        private int id;
        private string sex;
        private int age;
        private int life_length;
        private int levelOfFood; //We keep the level in the interval [0-10]
        private DateTime birth_date;
        public Animal(int id, string sex) {
            this.id = id;
            this.sex = sex;
            this.birth_date = DateTime.Now;
        }

        public int GetId() {
            return id;
        }

        public string GetSex() {
            return sex;
        }

        public int Age {
            get { return age; }
            set { age = value; }
        }

        public void SetLifeLength(int life_length) {
            this.life_length = life_length;
        }

        public DateTime GetBirthDate() {
            return birth_date;
        }

        public int GetLevelOfFood() {
            return levelOfFood;
        }

        public void SetLevelOfFood(int newLevel) {
            if(newLevel > 10) {
                levelOfFood = 10;
            } else if(newLevel < 0) {
                levelOfFood = 0;
            } else {
                levelOfFood = newLevel;
            }
        }

        public void Feed() { //We assume for now that every feed adds 3 to the levelOfFood
            if(levelOfFood + 3 > 10) {
                levelOfFood = 10;
            } else {
                levelOfFood += 3;
            }
        }
    }
}
