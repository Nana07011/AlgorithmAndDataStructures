using System;
namespace FileWork
{
    internal class Program
    {
        /// <summary>
        /// Главное меню программы
        /// Вариант 9: загрузка 4 ядер процессора
        /// </summary>
        static void Main()
        {
            CreateFile("cpu_data.csv"); //1 метод
            var Data = ReadFile("cpu_data.csv"); //2 метод
            var averages = ProcessData(Data); //3 метод
            FinalFile("cpu_data.csv", Data, averages); //4 метод
            Console.WriteLine("Ядра со средней загрузкой > 75%:");
            bool found = false;
            for (int i = 0; i < averages.Count; i++)
            {
                if (averages[i] > 75)
                {
                    Console.WriteLine($"Ядро {i + 1}: {averages[i]:F1}%");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Нет ядер со средней загрузкой выше 75%");
            }
        }
        /// <summary>
        /// Метод 1: Создаем файл с заголовком и случайными числами
        /// </summary>
        /// <param name="filename">Имя файла</param>
        static void CreateFile(string filename)
        {
            Random rnd = new Random();
            int Count = 0;
            Console.Write("Введите количество записей: ");
            while (!int.TryParse(Console.ReadLine(), out Count) || Count <= 0)
            {
                Console.Write("Ошибка! Введите положительное целое число: ");
            }
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("ID, Core1, Core2, Core3, Core4");
                for (int i = 1; i <= Count; i++)
                {
                    int core1 = rnd.Next(0, 101);
                    int core2 = rnd.Next(0, 101);
                    int core3 = rnd.Next(0, 101);
                    int core4 = rnd.Next(0, 101);
                    file.WriteLine($"{i},{core1},{core2},{core3},{core4}");
                }
            }
            Console.WriteLine("Файл создан.");
        }
        /// <summary>
        /// Метод 2: Читает файл и преобразует данные в список списков чисел
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Список строк данных, где строка это список из 5 чисел</returns>
        static List<List<double>> ReadFile(string filename)
        {
            var Data = new List<List<double>>();
            using (StreamReader file = new StreamReader(filename))
            {
                string heading = file.ReadLine();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    var row = new List<double>();
                    bool validRow = true;
                    foreach (string part in parts)
                    {
                        if (double.TryParse(part, out double value)) row.Add(value);
                        else
                        {
                            validRow = false;
                            break;
                        }
                    }
                    if (validRow && row.Count == 5) Data.Add(row);
                }
            }
            return Data;
        }
        /// <summary>
        /// Метод 3: Обработка данных файла
        /// </summary>
        /// <param name="Data">Данные из файла</param>
        /// <returns>Список из 4 элементов среднего значения</returns>
        static List<double> ProcessData(List<List<double>> Data)
        {
            if (Data == null || Data.Count == 0) return new List<double> { 0, 0, 0, 0 };
            double sumCore1 = 0, sumCore2 = 0, sumCore3 = 0, sumCore4 = 0;
            foreach (var row in Data)
            {
                sumCore1 += row[1];
                sumCore2 += row[2];
                sumCore3 += row[3];
                sumCore4 += row[4];
            }
            int rowsCount = Data.Count;
            var averages = new List<double>();
            averages.Add(sumCore1 / rowsCount);
            averages.Add(sumCore2 / rowsCount);
            averages.Add(sumCore3 / rowsCount);
            averages.Add(sumCore4 / rowsCount);
            Console.WriteLine($"Core1: {averages[0]:F1}%");
            Console.WriteLine($"Core2: {averages[1]:F1}%");
            Console.WriteLine($"Core3: {averages[2]:F1}%");
            Console.WriteLine($"Core4: {averages[3]:F1}%");
            return averages;
        }
        /// <summary>
        /// Метод 4: Запись с добавлением данных
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="OriginalData">Исходные данные(метод 2)</param>
        /// <param name="res">Результаты обработки(метод3)</param>
        static void FinalFile(string filename, List<List<double>> OriginalData, List<double> res)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("ID,Core1,Core2,Core3,Core4");
                foreach (var row in OriginalData)
                {
                    file.WriteLine($"{row[0]},{row[1]},{row[2]},{row[3]},{row[4]}");
                }
                file.WriteLine($"Core_avgs,{res[0]:F1},{res[1]:F1},{res[2]:F1},{res[3]:F1}");
            }
            Console.WriteLine("Файл обновлен");
            using (StreamReader file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}