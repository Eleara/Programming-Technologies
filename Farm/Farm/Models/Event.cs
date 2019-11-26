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
        private DateTime eventDate;
        private Animal eventAnimal;
        string typeOfEvent;
        //private enum type_of_event { birth, death, feed, copulation};
        //Event(int id, Animal event_animal, String type_of_event) {
        public Event(int id, Animal eventAnimal, string typeOfEvent) {
            this.id = id;
            eventDate = DateTime.Now;
            this.eventAnimal = eventAnimal;
            this.typeOfEvent = typeOfEvent;
        }

        public DateTime GetEventDate() {
            return eventDate;
        }

        public Animal GetEventAnimal() {
            return eventAnimal;
        }

        public int GetId()
        {
            return id;
        }

        public string GetTypeOfEvent()
        {
            return typeOfEvent;
        }
    }
}
