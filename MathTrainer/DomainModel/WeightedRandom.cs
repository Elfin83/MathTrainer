using System;
using System.Collections.Generic;
using System.Linq;

namespace MathTrainer
{
    public interface IWeightedItem
    {
        int Weight { get; set; }
    }

    public class WeightedRandom
    {
        public static T GetWeightedRandom<T>(List<T> itemList, Random rndm) where T : IWeightedItem
        {
            int rndMemberId = 0,
                totalWeight = 0,
                partSum = 0;
            T item = itemList.First();

            //Получаем сумму весов всех элементов
            //Таблицу значение-вес можно преобразовать в массив типа АБББВВГГГГ,
            //где количество каждого из элементов соответствет его весу. Размер такого массива - totalWeight
            foreach (var n in itemList)
            {
                totalWeight += n.Weight;
            }

            //Получаем индекс элемента в массиве, описанном выше (фактически никакой массив не создается)
            rndMemberId = rndm.Next(0, totalWeight);

            //Ищем какому значению из массива соответствует индекс rndMemberId
            //Каждой группе значений соответствет свой "частичный" вес: А 1, Б 1+3, В 4+2, Г 6+4
            //Искомому значению соответствует частичная сумма не превышающая rndMemberId

            foreach (var n in itemList)
            {
                if (rndMemberId < partSum)
                {
                    break;
                }
                partSum += n.Weight; //Добавляем значение веса очередного элемента
                item = n;
            }
            return item;
        }

    }
}
