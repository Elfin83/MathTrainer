using System;
using System.Collections.Generic;

namespace MathTrainer
{
    public class Model
    {
        private static IExercise exercise;
        private List<int> _numbers;
        private List<string> _operationTypes;      
        
        public List<int> Numbers {get; set;} 
        public List<string> OperationTypes { get; set; }

        public Model() { }

        public Model(List<int> numbers, List<string> operationTypes)
        {
            _numbers = numbers;
            _operationTypes = operationTypes;
        }

        public static IExercise ChooseExercise(List<int> numbers, List<string> operationTypes)
        {
            var rndm = new Random();
            string operationType = operationTypes[rndm.Next(0, operationTypes.Count)];
            int num1 = rndm.Next(0, 10);
            int num2 = numbers[rndm.Next(0, numbers.Count)];
            if (operationType == "Деление")
            {
                while (num2 == 0)
                {
                    num2 = numbers[rndm.Next(0, numbers.Count)];
                }
                exercise = new Dividing(num1, num2);
            }
            else if (operationType == "Умножение")
            {
                exercise = new Multiplication(num1, num2);
            }
                return exercise;
        }
    }
}
