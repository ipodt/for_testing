//Задача №2
//задача решена с помощью алгоритма Нарайаны

using System;
using System.IO;

namespace task_2
{
    class Task2
    {
		public static System.IO.StreamWriter fileWriter = new System.IO.StreamWriter("D:\\output.txt");

		public static int findMaxIndex(int[] permutation)
		{
			for (int i = permutation.Length - 2; i >= 0; i--)
			{
				if (permutation[i] < permutation[i + 1])
				{
					return i;
				}
			}
			return -1;
		}

		public static int findIndexBiggerElement(int[] permutation, int element)
		{
			for (int i = permutation.Length - 1; i >= 0; i--)
			{
				if (permutation[i] > element)
				{
					return i;
				}
			}
			return -1;
		}

		public static void swap(int[] permutation, int i, int j)
		{
			int temp = permutation[i];
			permutation[i] = permutation[j];
			permutation[j] = temp;
		}

		public static void reverse(int[] permutation, int index)
		{
			int shift = index + 1;
			for (int i = 0; i < (permutation.Length - shift) / 2; i++)
			{
				int temp = permutation[shift + i];
				permutation[shift + i] = permutation[permutation.Length - i - 1];
				permutation[permutation.Length - i - 1] = temp;
			}
		}
		public static void printArray(int[] arr)
        {
			for (int i = 0; i < arr.Length; i++)
            {
				fileWriter.Write(arr[i] + " ");
            }

			fileWriter.WriteLine();
        }

		public static void permutationGenerator(int[] permutation) //главная функция, генерирующая перестановки с помощью алгоритма Нарайаны
		{
			printArray(permutation);

			int k = 1;

			int index = findMaxIndex(permutation);
			for (; index != -1;)
			{
				int element = permutation[index];
				int swapIndex = findIndexBiggerElement(permutation, element);
				swap(permutation, index, swapIndex);
				reverse(permutation, index);
				printArray(permutation);
				k++; 
				index = findMaxIndex(permutation);
			}

			fileWriter.WriteLine(k); //выводим кол-во перестановок
			fileWriter.Close();
		}
		
		static void Main(string[] args)
        {
		}
    }
}
