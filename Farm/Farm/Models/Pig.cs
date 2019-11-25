using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Pig : Animal
    {
        public Pig(int id, string sex) : base(id, sex) {
            Random r = new Random();
            SetLifeLength(r.Next(15, 20)); //average life of a pig
        }
    }
}
