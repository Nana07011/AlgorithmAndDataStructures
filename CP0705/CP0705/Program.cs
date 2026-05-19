using System;
namespace CP0705
{
    internal class Program
    {
        static int[]? Solution(int[] array,int target) //1 задача на словарь
        {
            if (array is null || array.Length < 2) return null;
            // 4 2 7 1 5 target = 3
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            // 4:0 2:1 7:2  
            for(int i = 0; i < array.Length; i++)
            {
                int key = array[i];
                if (pairs.ContainsKey(target - key))
                    return [i, pairs[target - key]];
                else pairs[key] = i;
            }
            return null;
        }
        static bool? Solution1(int[] array) //2 задача
        {
            if (array is null) return null;
            if (array.Length < 2) return false;
            HashSet<int> pairs = new HashSet<int>(array);
            return pairs.Count != array.Length;
        }
        static bool Solution2(int[] array)
        {
            if (array is null) return false;
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            foreach (int elem in array)
            {
                if(pairs.ContainsKey(elem)) 
                    pairs[elem]++;
                else pairs[elem] = 1;
            }
            foreach(var pair in pairs)
            {
                if (pair.Value == 1)
                    return false;
            }
            return true;
        }
        static int[]? Solution3(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null) return null;
            HashSet<int> set = new HashSet<int>(array1);
            HashSet<int> res = new HashSet<int>();
            foreach (int i in array2)
            {
                if 
            }
            
        }
        static void Print(HashSet<int> numbs, int elem) //начало практики
        {
            if (numbs is null) return;
            if (numbs.Add(elem))
                Console.WriteLine("Added");
            else Console.WriteLine("Not added");
        }
        static void Main()
        {
            Solution3();
            Console.WriteLine(Solution2([2, 3, 3, 1]));
            Console.WriteLine(Solution2([2, 3, 3, 1, 2, 1]));
            Console.WriteLine(Solution2(null));
            bool? f = Solution1([4, 2, 1, 5, 8]); //2 задача
            if (f.HasValue) Console.WriteLine(f);
            
            int[] array = [4, 2, 1, 5, 8]; //1 задача
            int[]? res = Solution(array, 7);
            if (res is not null)
                Console.WriteLine(res[0] + " " + res[1]);

            // Множество не хранит дубликаты, то есть
            // все элементы уникальные, при попытке добавить
            // дубликат он не добавляется
            // Элементы хранятся в произвольном порядке
            // Создали пустое множество, которое хранит целые числа
            HashSet<int> numbers = new HashSet<int>();
            Print(numbers, 10);
            Print(numbers, 10);
            bool flag = numbers.Add(12); // flag = True
            Console.WriteLine(numbers.Remove(10)); //true
            Console.WriteLine(numbers.Remove(15)); //false
            if(numbers.Contains(20))
                Console.WriteLine("Элемент 20 есть в множестве");
            int count = numbers.Count;
            int sum = 0;
            foreach(int num in numbers)
            {
                sum += num;
                Console.WriteLine(num);
            }
            Console.WriteLine($"Сумма элементов = {sum}");
        }
    }
}
//словари и множества кр