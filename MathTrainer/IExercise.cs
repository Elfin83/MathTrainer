using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTrainer
{
    public interface IExercise
    {
        string ExerciseText();
        string ExerciseAnswerText();
        decimal Answer();
    }
}
