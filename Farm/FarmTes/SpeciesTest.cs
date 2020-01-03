using Microsoft.VisualStudio.TestTools.UnitTesting;
using Farm;
using System.Data;
using System;
using Farm.Models;
using Farm.Managers;

namespace FarmTes {

    [TestClass]
    class SpeciesTest {

        [TestMethod]
        public void TestSpecies() {
            Animal animal = new Chicken(13, "F");
            Console.WriteLine(animal.GetType());
        }
    }
}
