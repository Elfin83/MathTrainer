using System;
using System.Collections.Generic;

namespace MathTrainer
{
    public class ExerciseManager
    {
        private static IExercise exercise;    
        
        public List<int> Numbers {get; set;} 
        public List<MathOperations> OperationTypes { get; set; }

        public ExerciseManager() { }

        public static IExercise ChooseExercise(List<int> numbers, List<MathOperations> operationTypes)
        {
            var rndm = new Random();
            MathOperations operationType = operationTypes[rndm.Next(0, operationTypes.Count)];
            int num1 = rndm.Next(0, 10);
            int num2 = numbers[rndm.Next(0, numbers.Count)];
            if (operationType == MathOperations.Делить)
            {
                while (num2 == 0)
                {
                    num2 = numbers[rndm.Next(0, numbers.Count)];
                }
                exercise = new Dividing(num1, num2);
            }
            else if (operationType == MathOperations.Умножать)
            {
                exercise = new Multiplication(num1, num2);
            }
                return exercise;
        }
    }
}
