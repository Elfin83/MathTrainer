using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
namespace MathTrainer
{
    public class ExerciseManager
    {
        public static IExercise ChooseExercise(List<int> numbers, List<MathOperations> operationTypes)
        {
            Contract.Requires<ArgumentNullException>(numbers != null, "numbers");
            Contract.Requires<ArgumentNullException>(operationTypes != null, "operationTypes");
            Contract.Requires<ArgumentOutOfRangeException>(numbers.Count > 0, "numbers");
            Contract.Requires<ArgumentOutOfRangeException>(operationTypes.Count > 0, "operationTypes");
            Contract.Requires<ArgumentOutOfRangeException>(numbers.Count <= 10, "numbers");
            Contract.Requires<ArgumentOutOfRangeException>(operationTypes.Count <= 2, "operationTypes");
            Contract.ForAll(operationTypes, i => i != MathOperations.None);
            //Перенести в UnitTests
            Contract.Requires(operationTypes.Count == operationTypes.Distinct().Count());
            Contract.Requires(numbers.Count == numbers.Distinct().Count());

            IExercise exercise = null;
            var rndm = new Random();
            MathOperations operationType = operationTypes[rndm.Next(0, operationTypes.Count)];
            int num1 = rndm.Next(0, 10);
            int num2 = numbers[rndm.Next(0, numbers.Count)];
            if (operationType == MathOperations.Делить)
            {
                //To avoid dividing by zero
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
