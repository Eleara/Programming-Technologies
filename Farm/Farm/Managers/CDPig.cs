﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;

namespace Farm.Managers {
    public class CDPig : ICreateDelete {
        public void Create(Animal animal, DatabaseManager manager) {
            int Id = animal.GetId();
            string Sex = animal.GetSex();
            DateTime Birth_date = animal.GetBirthDate();
            manager.ExecuteInstruction($"insert into Pigs(Id, Sex, Birth_date) values ({Id}, '{Sex}', '{Birth_date.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");
        }
        public void Delete(Animal animal, DatabaseManager manager) {
            int Id = animal.GetId();
            manager.ExecuteInstruction($"delete from Pigs where Id = {Id}");
        }
    }
}
