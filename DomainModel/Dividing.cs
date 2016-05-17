
namespace MathTrainer
{
    public class Dividing : IExercise
    {
        private int _num1 = 0, _num2 = 0, _divisible = 0;

        public Dividing(int num1, int num2)
        {
            _num1 = num1;
            _num2 = num2;
            _divisible = _num1 * _num2;
        }

        public string ExerciseText()
        {
            return _divisible.ToString() + " : " + _num2.ToString();
        }

        public string ExerciseAnswerText()
        {
            return _divisible.ToString() + " : " + _num2.ToString() + " = " + _num1.ToString();
        }

        public decimal Answer()
        {
            return _num1;
        }
    }
}
