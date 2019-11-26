using Farm;
using Farm.Models;
using Farm.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Event {
        private int id;
        private DateTime event_date;
        private Animal event_animal;
        string type_of_event;
        //private enum type_of_event { birth, death, feed, copulation};
        //Event(int id, Animal event_animal, String type_of_event) {
        public Event(int id, Animal event_animal, string type_of_event) {
            this.id = id;
            event_date = DateTime.Now;
            this.event_animal = event_animal;
            this.type_of_event = type_of_event;
        }

        public DateTime getEventDate() {
            return event_date;
        }

        public Animal getEventAnimal() {
            return event_animal;
        }

        public int getId()
        {
            return id;
        }

        public string getTypeOfEvent()
        {
            return type_of_event;
        }
    }
}
