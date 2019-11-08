using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Animal
    {
        private int Id;
        private string Species;
        private string Sex;
        private DateTime Birth_date;
        public Animal(int Id, string Species, string Sex)
        {
            this.Id = Id;
            this.Species = Species;
            this.Sex = Sex;
            this.Birth_date = DateTime.Now;
        }

        public Animal(int Id, string Species, string Sex, DateTime Birth_date)
        {
            this.Id = Id;
            this.Species = Species;
            this.Sex = Sex;
            this.Birth_date = Birth_date;
        }

        public int getId()
        {
            return Id;
        }

        public string getSpecies()
        {
            return Species;
        }

        public string getSex()
        {
            return Sex;
        }

        public DateTime getBirthDate()
        {
            return Birth_date;
        }
    }
}
