//Задача №3

using System;
using System.Collections.Generic;

namespace task3
{
    class NumberAndNumberOfHoles : IComparable
    {
        public int number;
        public int numberOfHoles;

        public NumberAndNumberOfHoles(int number, int numberOfHoles)
        {
            this.number = number;
            this.numberOfHoles = numberOfHoles;
        }

        public int CompareTo(object obj)
        {
            NumberAndNumberOfHoles comparableObject = obj as NumberAndNumberOfHoles;

            if (comparableObject != null)
            {
                if (this.numberOfHoles < comparableObject.numberOfHoles)
                    return -1;
                else if (this.numberOfHoles > comparableObject.numberOfHoles)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Data type does not match parameter");
            }
        }
    }

    class Task3
    {
        static void sortByHoles(int[] arr) //главная функция сортировки массива по возрастанию кол-ва дырок
        {
            Dictionary<int, int> holes = new Dictionary<int, int> //словарь, ключом которого является число, а значением - кол-во дырок в этом числе
            {
                {0, 1},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 1},
                {5, 0},
                {6, 1},
                {7, 0},
                {8, 2},
                {9, 1}
            };

            NumberAndNumberOfHoles[] arrayWithNumbersOfHoles = new NumberAndNumberOfHoles[arr.Length]; //массив пар { число, кол - во дырок в нём}

            for (int i = 0; i < arrayWithNumbersOfHoles.Length; i++) //заполняем массив пар
            {
                arrayWithNumbersOfHoles[i] = new NumberAndNumberOfHoles(arr[i], holes[arr[i]]);
            }

            Array.Sort(arrayWithNumbersOfHoles); //сортируем массив пар по возрастанию кол-ва дырок

            for (int i = 0; i < arrayWithNumbersOfHoles.Length; i++) //заполняем(сортируем) исходный массив
            {
                arr[i] = arrayWithNumbersOfHoles[i].number;
            }
        }

        static void Main(string[] args)
        {
        }       
    }
}
