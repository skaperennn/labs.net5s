using System;
using MyQueue;
//події
//очищення колекції
//додавання елементу
//видалення елементу

//виключні ситуації
//видалити елемент з пустої черги
//відсутнє значення за ключем (черга пуста)

namespace lab1._5s
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Updated += mes => Console.WriteLine(mes);

            while (true)
            {
                Console.WriteLine("1. Додати елемент");
                Console.WriteLine("2. Видалити елемент");
                Console.WriteLine("3. Значення першого елементу");
                Console.WriteLine("4. Знайти перший індекс елементу за значенням");
                Console.WriteLine("5. Видалити чергу");
                Console.WriteLine("6. Вивести чергу");
                Console.WriteLine("7. Вихiд з програми\n");

               
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                try
                {
                    switch (key)
                    {
                        case '1':
                            Console.WriteLine("Введiть значення елементу:");
                            int tmp = int.Parse(Console.ReadLine());
                            queue.Enqueue(tmp);
                            Console.WriteLine();
                            break;
                        case '2':
                            queue.Dequeue();
                            Console.WriteLine();
                            break;
                        case '3':
                            Console.WriteLine($"Значення першого елементу: {queue.Peek()}");
                            break;
                        case '4':
                            Console.WriteLine("Введiть значення: ");
                            tmp = int.Parse(Console.ReadLine());
                            if (queue.Contains(tmp).check)
                                Console.WriteLine($"Так, його iндекс: {queue.Contains(tmp).count}");
                            break;
                        case '5':
                            queue.Clear();
                            Console.WriteLine();
                            break;
                        case '6':
                                Console.Write("Поточна черга:");
                                foreach (var elem in queue)
                                    Console.Write(String.Format("{0,3}", elem.ToString()));              
                            Console.WriteLine();
                            break;
                        case '7':
                            Environment.Exit(0);
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                            break;
                    }
                } catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
    }
}
