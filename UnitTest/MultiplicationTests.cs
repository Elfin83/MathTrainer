using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTrainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTrainer.Tests
{
    [TestClass()]
    public class MultiplicationTests
    {
        Multiplication instance = new Multiplication(3, 2);

        [TestMethod()]
        public void AnswerTest()
        {
            Assert.AreEqual(6, instance.Answer());
        }

        [TestMethod()]
        public void ExerciseTextTest()
        {
            string expected = "3 X 2";
            string exText = instance.ExerciseText();
            Assert.AreEqual(expected, exText, "Неверный формат задания.");
        }

        [TestMethod()]
        public void ExerciseAnswerTextTest()
        {
            string expected = "3 X 2 = 6";
            string exText = instance.ExerciseAnswerText();
            Assert.AreEqual(expected, exText, "Неверный формат ответа.");
        }
    }
}