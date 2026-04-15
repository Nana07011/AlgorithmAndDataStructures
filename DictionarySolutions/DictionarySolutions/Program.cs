using System;
namespace DictionarySolutions
{
    internal class Program
    {
        static Dictionary<string, string> phoneBook = new Dictionary<string, string>
    ();
        static void Main()
        {
            string s = "программирование";//1задача Часть10 практика4
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach ( char c in s)
            {
                if (count.ContainsKey(c)) count[c]++;
                else count[c] = 1;
            }
            Console.WriteLine("Результат:");
            foreach (var a in count)
                Console.WriteLine(a);


            while (true)//4задача Часть10 практика4
            {
                Console.WriteLine("1 - Добавить контакт");
                Console.WriteLine("2 - Найти телефон");
                Console.WriteLine("3 - Удалить контакт");
                Console.WriteLine("4 - Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        FindContact();
                        break;
                    case "3":
                        DeleteContact();
                        break;
                    case "4":
                        Console.WriteLine("Хорошего дня!");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
        static void AddContact()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine("Контакт с таким именем уже существует.");
                return;
            }
            Console.Write("Введите телефон: ");
            string phone = Console.ReadLine();

            phoneBook.Add(name, phone);
            Console.WriteLine("Контакт добавлен");
        }
        static void FindContact()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine($"Телефон {name}: {phoneBook[name]}");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }
        static void DeleteContact()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            if (phoneBook.Remove(name))
            {
                Console.WriteLine("Контакт удален");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }
    }
}