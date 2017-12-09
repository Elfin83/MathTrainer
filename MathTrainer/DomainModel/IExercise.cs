using System.Diagnostics.Contracts;

namespace MathTrainer
{
    public interface IExercise
    {        
        string ToString();
        string ExerciseAnswerText();
        decimal Answer();
    }
}
