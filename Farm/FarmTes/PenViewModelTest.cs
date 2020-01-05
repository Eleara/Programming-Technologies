using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Farm.ViewModels;
using Farm.Commands;
using Presentation.ViewModel;

namespace FarmTes {
    [TestClass]
    public class PenViewModelTest {
        [TestMethod]
        public void CanUpdateTest() {
            PenViewModel penViewModel = new PenViewModel();
            Assert.IsTrue(penViewModel.CanUpdate);
            penViewModel.Pen = null;
            Assert.IsFalse(penViewModel.CanUpdate);
        }

        [TestMethod]
        public void AddingAnimalTest() {
            PenViewModel penViewModel = new PenViewModel();
            penViewModel.RemoveAllAnimals();
            penViewModel.AddChicken();
            Assert.AreEqual(penViewModel.Pen.GetAnimals().Count, 1);
        }

        [TestMethod]
        public void DeletingAnimalTest() {
            PenViewModel penViewModel = new PenViewModel();
            penViewModel.RemoveAllAnimals();
            penViewModel.AddChicken();
            penViewModel.SelectedAnimal = penViewModel.Pen.GetAnimal(0);
            penViewModel.RemoveAnimal();
            Assert.AreEqual(penViewModel.Pen.GetAnimals().Count, 0);
        }
    }
}
