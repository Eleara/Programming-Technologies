using Farm;
using Farm.Models;
using Farm.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FarmTes
{
    [TestClass]
    public class EventTest
    {
        /*
        [TestMethod]
        public void TestingEventCreationAndDeletion()
        {
            DatabaseManager manager = new DatabaseManager();
            Pig pig1 = new Pig(1, "M");
            AnimalManager animalManager = new AnimalManager();
            animalManager.CreateAnimal(pig1, manager);
            Event ev1 = new Event(1, pig1, "death");
            EventManager eventManager = new EventManager();
            eventManager.CreateEvent(ev1, manager);
            DataTable outcome = manager.RunQuery("select * from Events where Id = 1");
            Assert.AreEqual(1, outcome.Rows[0]["Animal_id"]);
            Assert.AreEqual("death", outcome.Rows[0]["Type_of_event"]);
            eventManager.DeleteEvent(ev1, manager);
            animalManager.DeleteAnimal(pig1, manager);
        }
        */

    }
}
