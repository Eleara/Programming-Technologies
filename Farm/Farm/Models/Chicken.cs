using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Chicken : Animal{
        
        public Chicken(int id, string sex) : base(id, sex) {
            Random r = new Random();
            SetLifeLength(r.Next(8, 12)); //average life of a chicken
        }
    }
}
