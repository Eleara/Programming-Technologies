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
    public class AnimalTest
    {
        /*
          [TestMethod]
          public void TestingAnimals() {
              DatabaseManager manager = new DatabaseManager();
              Cow cow1 = new Cow(01, "male");
              Chicken chicken1 = new Chicken(01, "female");
              Assert.AreEqual(cow1.GetId(), 01);
              Assert.AreEqual(cow1.GetSex(), "male");
              Assert.AreNotEqual(cow1.GetType(), chicken1.GetType());
              Animal cow2 = new Cow(02, "female");
              Animal pig1 = new Pig(01, "female");
              Assert.AreNotEqual(cow2.GetType(), pig1.GetType());
              AnimalManager animalManager = new AnimalManager();
              //Assert.IsTrue(animalManager.Copulate(cow1, cow2));
          }

          [TestMethod]
          public void TestingAnimalCreationAndDeletion()
          {
              DatabaseManager manager = new DatabaseManager();
              Pig pig1 = new Pig(1, "M");
              AnimalManager animalManager = new AnimalManager();
              animalManager.CreateAnimal(pig1, manager);
              DataTable outcome = manager.RunQuery("select * from Pigs where Id = 1");
              Assert.AreEqual("M", outcome.Rows[0]["Sex"]);
              animalManager.DeleteAnimal(pig1, manager);
          }
          */

        [TestMethod]
        public void TestingAnimalReading()
        {
            Pen pen = new Pen();
            Assert.AreEqual(6, pen.GetAnimals().Count);
        }
    }
}
