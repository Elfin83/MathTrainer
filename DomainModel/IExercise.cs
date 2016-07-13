using System.Diagnostics.Contracts;

namespace MathTrainer
{
    public interface IExercise
    {        
        string ExerciseText();
        string ExerciseAnswerText();
        decimal Answer();
    }
}
