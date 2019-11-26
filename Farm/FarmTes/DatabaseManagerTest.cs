using Microsoft.VisualStudio.TestTools.UnitTesting;
using Farm;
using System.Data;
using System;

namespace FarmTes
{
    [TestClass]
    public class DatabaseManagerTest1
    {
        [TestMethod]
        public void TestingAlreadyInsertedRow()
        {
            DatabaseManager manager = new DatabaseManager();
            DataTable outcome = manager.RunQuery("select * from Cows where Id = 1");
            Assert.AreEqual("M", outcome.Rows[0]["Sex"]);
        }

        [TestMethod]
        public void InsertingRowAndTesting()
        {
            DatabaseManager manager = new DatabaseManager();
            manager.ExecuteInstruction("insert into Cows(Id, Sex, Birth_date) values (2, 'F', '08-11-19 10:34:00')");
            DataTable outcome = manager.RunQuery("select * from Cows where Id = 2");
            Assert.AreEqual("F", outcome.Rows[0]["Sex"]); 
            manager.ExecuteInstruction("delete from Cows where Id=2");
        }
    }
}
