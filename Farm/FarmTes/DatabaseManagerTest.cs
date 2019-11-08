using Microsoft.VisualStudio.TestTools.UnitTesting;
using Farm;
using System.Data;
using System;

namespace FarmTest
{
    [TestClass]
    public class DatabaseManagerTest1
    {
        [TestMethod]
        public void TestingAlreadyInsertedRow()
        {
            DatabaseManager manager = new DatabaseManager();
            DataTable outcome = manager.RunQuery("select * from Animals where Id = 1");
            Assert.AreEqual("Cow", outcome.Rows[0]["Species"]);
            Assert.AreEqual("M", outcome.Rows[0]["Sex"]);
        }

        [TestMethod]
        public void InsertingRowAndTesting()
        {
            DatabaseManager manager = new DatabaseManager();
            manager.ExecuteInstruction("insert into Animals(Id, Species, Sex, Birth_date) values (2, 'Pig', 'F', '08-11-19 10:34:00')");
            DataTable outcome = manager.RunQuery("select * from Animals where Id = 2");
            Assert.AreEqual("Pig", outcome.Rows[0]["Species"]); 
            DateTime date = new DateTime(2019, 8, 11, 10, 34, 0);
            Assert.AreEqual(date, outcome.Rows[0]["Birth_date"]);
            manager.ExecuteInstruction("delete from Animals where Id=2");
        }
    }
}
