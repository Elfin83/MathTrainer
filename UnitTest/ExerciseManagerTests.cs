using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTrainer;
using System;
using System.Collections.Generic;


namespace MathTrainer.Tests
{
    [TestClass()]
    public class ExerciseManagerTests
    {
        [TestMethod()]
        public void ChooseExerciseTest()
        {
            var listOfNumbers = new List<int> {0, 1, 2, 3};
            var listOfOperations1 = new List<MathOperations> { MathOperations.Делить, MathOperations.Умножать};                    
            var listOfOperations2 = new List<MathOperations> { MathOperations.Делить};
            var listOfOperations3 = new List<MathOperations> { MathOperations.Умножать };

            Assert.IsNotNull(ExerciseManager.ChooseExercise(listOfNumbers, listOfOperations1));
            Assert.IsNotNull(ExerciseManager.ChooseExercise(listOfNumbers, listOfOperations2));
            Assert.IsNotNull(ExerciseManager.ChooseExercise(listOfNumbers, listOfOperations3));

            Assert.IsInstanceOfType(ExerciseManager.ChooseExercise(listOfNumbers, listOfOperations2), typeof(Dividing));
            Assert.IsInstanceOfType(ExerciseManager.ChooseExercise(listOfNumbers, listOfOperations3), typeof(Multiplication));
        }
    }
}