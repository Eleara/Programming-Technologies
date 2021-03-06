﻿using Farm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Managers
{
    public class EventManager
    {
        public void CreateEvent(Event ev, DatabaseManager manager)
        {
            int Id = ev.GetId();
            string Type_of_event = ev.GetTypeOfEvent();
            DateTime Date = ev.GetEventDate();
            Animal animal = ev.GetEventAnimal();
            int Animal_id = animal.GetId();
            manager.ExecuteInstruction($"insert into Events(Id, Animal_id, Date, Type_of_event) values ({Id}, '{Animal_id}', '{Date.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{Type_of_event}')");
        }

        public void DeleteEvent(Event ev, DatabaseManager manager)
        {
            int Id = ev.GetId();
            manager.ExecuteInstruction($"delete from Events where Id = {Id}");
        }

        public void DeleteAllEvents(DatabaseManager manager) {
            manager.ExecuteInstruction($"delete from Events");
        }

        public int FindId(DatabaseManager manager) {
            int returnId = 0;
            DataTable outcomeId = manager.RunQuery($"select MAX(Id) as m from Events");
            if (outcomeId.Rows[0]["m"] != DBNull.Value) {
                returnId = Convert.ToInt32(outcomeId.Rows[0]["m"]) + 1;
            }
            return returnId;
        }
    }
}
