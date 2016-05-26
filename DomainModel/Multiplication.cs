using System;
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
            return String.Format("{0} X {1}", _num1.ToString(), _num2.ToString());
        }

        public string ExerciseAnswerText()
        {
            return String.Format("{0} X {1} = {2}", _num1.ToString(), _num2.ToString(), Answer().ToString());
        }

        public decimal Answer()
        {
            return _num1 * _num2;
        }
    }
}
