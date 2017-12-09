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

        public override string ToString()
        {
            return String.Format("{0} X {1}", _num2.ToString(), _num1.ToString());
        }

        public string ExerciseAnswerText()
        {
            return String.Format("{0} X {1} = {2}", _num2.ToString(), _num1.ToString(), Answer());
        }

        public decimal Answer()
        {
            decimal answer = _num1 * _num2;
            return answer;
        }
    }
}
