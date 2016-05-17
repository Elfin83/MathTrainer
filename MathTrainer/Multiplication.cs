using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTrainer
{
    public class Multiplication : IExercise
    {
        private int _num1, _num2;

        public Multiplication(int num1, int num2)
        {
            _num1 = num1;
            _num2 = num2;
        }

        public string ExerciseText()
        {
            return _num1.ToString() + " X " + _num2.ToString();
        }

        public string ExerciseAnswerText()
        {
            return _num1.ToString() + " X " + _num2.ToString() + " = " + Answer().ToString();
        }

        public decimal Answer()
        {
            return _num1 * _num2;
        }
    }
}
