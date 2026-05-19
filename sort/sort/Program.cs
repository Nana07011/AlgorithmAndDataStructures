using System;
namespace sort
{
    internal class Program
    {
        static void Main()
        {
            int[] array = { 5, 2, 8, 1, 3 };
            QuickSort(array, 0 , array.Length-1);
            foreach(int i in array)
            Console.WriteLine(i);
            int[] arr = { 5, 2, 8, 1, 9, 3 };
            int[]sorted = Mergesort(arr);
            foreach (int i in sorted) 
                Console.WriteLine(i);
        }
        static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right) return;
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[right]);
            int pivotIndex = i + 1;
            
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }*/
        static int[] Mergesort(int[] array)
        {
            if(array.Length <= 1) return array;
            int mid = array.Length / 2;
            int[]left = new int[mid];
            int[]right= new int[array.Length - mid];

            for (int i = 0; i < mid; i++) left[i] = array[i];
            for (int i = 0; i < right.Length; i++) right[i] = array[mid + i];
            left = Mergesort(left);
            right = Mergesort(right);

            return Merge(left, right);
        }
        static int[] Merge(int[]left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j]) result[k++] = left[i++];
                else result[k++] = right[j++];
            }
            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right [j++];
            return result;
        }
    }
}