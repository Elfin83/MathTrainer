using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
namespace MathTrainer
{
    public interface IChooseExcerciseStrategy
    {
        IExercise ChooseExercise(List<int> numbers);
    }

    public class ChooseDividingExcercise : IChooseExcerciseStrategy
    {
        public IExercise ChooseExercise(List<int> numbers)
        {
            var rndm = new Random();
            int num1 = rndm.Next(0, 10);
            int num2 = numbers[rndm.Next(0, numbers.Count)];
            //To avoid dividing by zero
            while (num2 == 0)
            {
                num2 = numbers[rndm.Next(0, numbers.Count)];
            }
            return new Dividing(num1, num2);
        }
    }

    public class ChooseMultiplicationExcercise : IChooseExcerciseStrategy
    {
        public IExercise ChooseExercise(List<int> numbers)
        {
            var rndm = new Random();
            int num1 = rndm.Next(0, 10);
            int num2 = numbers[rndm.Next(0, numbers.Count)];
            return new Multiplication(num1, num2);
        }
    }

    public class ExerciseManager
    {
        private List<MathOperations> _operationTypes;
        private List<int> _numbers;
        public IChooseExcerciseStrategy ContextStrategy { get; set; }

        public ExerciseManager(List<int> numbers, List<MathOperations> operationTypes)
        {
            _operationTypes = operationTypes;
            _numbers = numbers;            
        }
        public IExercise ChooseExercise()
        {
            ContextStrategy = ChooseExerciseType(_operationTypes);
            return ContextStrategy.ChooseExercise(_numbers);
        }

        private IChooseExcerciseStrategy ChooseExerciseType(List<MathOperations> operationTypes)
        {
            var rndm = new Random();
            MathOperations operationType = _operationTypes[rndm.Next(0, _operationTypes.Count)];
            switch (operationType)
            {
                case MathOperations.Делить: 
                    return new ChooseDividingExcercise();
                   
                case MathOperations.Умножать:                
                    return new ChooseMultiplicationExcercise();
             
                default:
                    return null;
            }
        }
    }
}
