namespace MathTrainer
{
    public class Statistics
    {
        private static int _answersCount,
            _correctAnswersCount;

        public static int AnswersCount
        {
            get { return _answersCount; }
            set { _answersCount = value; }
        }

        public static int CorrectAnswersCount
        {
            get { return _correctAnswersCount; }
            set { _correctAnswersCount = value; }
        }
    }
}
