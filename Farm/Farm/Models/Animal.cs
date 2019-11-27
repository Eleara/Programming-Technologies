using Farm;
using Farm.Models;
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
        private int lifeLength;
        private int levelOfFood; //We keep the level in the interval [0-10]
        private DateTime birthDate;
        public Animal(int id, string sex) { //for creating a new Animal
            this.id = id;
            this.sex = sex;
            this.birthDate = DateTime.Now;
            this.levelOfFood = 10;
        }

        public Animal(int id, string sex, int lifeLength, int levelOfFood, DateTime birthDate) {
            this.id = id;
            this.sex = sex;
            this.lifeLength = lifeLength;
            this.levelOfFood = levelOfFood;
            this.birthDate = birthDate;
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

        public void SetLifeLength(int lifeLength) {
            this.lifeLength = lifeLength;
        }

        public int GetLifeLength() {
            return lifeLength;
        }

        public DateTime GetBirthDate() {
            return birthDate;
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

        public void Feed()
        { //We assume for now that every feed adds 3 to the levelOfFood
            if (levelOfFood + 3 > 10) {
                levelOfFood = 10;
            } else {
                levelOfFood += 3;
            }
        }

    }
}
