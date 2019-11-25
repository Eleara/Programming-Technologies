using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    public class Event {
        private DateTime event_date;
        private Animal event_animal;
        private enum type_of_event { birth, death, feed, copulation};

        Event(Animal event_animal, String type_of_event) {
            event_date = DateTime.Now;
            this.event_animal = event_animal;
        }

        public DateTime getEventDate() {
            return event_date;
        }

        public Animal getEventAnimal() {
            return event_animal;
        }
    }
}
