using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Cow : Animal
    {
        public Cow(int id, string sex) : base(id, sex) {
            Random r = new Random();
            SetLifeLength(r.Next(18, 22)); //average life of a cow
        }

        public Cow(int id, string sex, int lifeLength, int levelOfFood, DateTime birthDate) :
            base(id, sex, lifeLength, levelOfFood, birthDate) { }
    }
}
