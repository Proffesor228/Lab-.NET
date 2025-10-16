using System;

namespace ConsoleLab
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА ===");
                Console.WriteLine("1. Задание 2");
                Console.WriteLine("2. Задание 3");
                Console.WriteLine("3. Задание 4");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите номер задания: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Zad1();
                        break;
                    case "2":
                        Zad2();
                        break;
                    case "3":
                        Zad3();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Zad1()
        {
            Console.Clear();
            Console.WriteLine("=== КОЛИЧЕСТВО ДВУХЗНАЧНЫХ ЧИСЕЛ ===");

            Console.WriteLine("Введите числа через пробел:");
            string input = Console.ReadLine();

            string[] numbers = input.Split(' ');
            int count = 0;

            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int num))
                {
                    if (num >= 10 && num <= 99)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Количество двухзначных чисел: {count}");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        static void Zad2()
        {
            Console.Clear();
            Console.WriteLine("=== ВЫВОД ЧИСЛА N РАЗ ===");

            Console.Write("Введите число K: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число N (N > 0): ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Ошибка: N должно быть больше 0!");
            }
            else
            {
                Console.Write($"Число {k} выведено {n} раз: ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        static void Zad3()
        {
            Console.Clear();
            Console.WriteLine("=== КОЛИЧЕСТВО ЧИСЕЛ В ПОСЛЕДОВАТЕЛЬНОСТИ ===");

            Console.WriteLine("Введите последовательность целых чисел (оканчивается нулём):");

            int count = 0;
            int number;

            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number != 0)
                {
                    count++;
                }
            } while (number != 0);

            Console.WriteLine($"Количество чисел в последовательности: {count}");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}
