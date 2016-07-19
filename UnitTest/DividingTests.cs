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
    public class DividingTests
    {
        Dividing instance = new Dividing(3, 2);

        [TestMethod()]
        public void ExerciseTextTest()
        {
            string expected = "6 : 2";
            string exText = instance.ToString();
            Assert.AreEqual(expected, exText, "Неверный формат задания.");
        }

        [TestMethod()]
        public void ExerciseAnswerTextTest()
        {
            string expected = "6 : 2 = 3";
            string exText = instance.ExerciseAnswerText();
            Assert.AreEqual(expected, exText, "Неверный формат ответа.");
        }

        [TestMethod()]
        public void AnswerTest()
        {
            Assert.AreEqual("3", instance.Answer(), "Неверный ответ.");
        }
    }
}