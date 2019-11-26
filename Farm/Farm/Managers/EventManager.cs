using Farm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Managers
{
    public class EventManager
    {
        public void CreateEvent(Event ev, DatabaseManager manager)
        {
            int Id = ev.getId();
            string Type_of_event = ev.getTypeOfEvent();
            DateTime Date = ev.getEventDate();
            Animal animal = ev.getEventAnimal();
            int Animal_id = animal.GetId();
            manager.ExecuteInstruction($"insert into Events(Id, Animal_id, Date, Type_of_event) values ({Id}, '{Animal_id}', '{Date.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{Type_of_event}')");
        }

        public void DeleteEvent(Event ev, DatabaseManager manager)
        {
            int Id = ev.getId();
            manager.ExecuteInstruction($"delete from Events where Id = {Id}");
        }
    }
}
