using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLaba1
{
    struct Student
    {
        public string Name;
        public int Age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
        }
    }
    class laba1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите номер задания (1, 2)");
            string z = Console.ReadLine();
            switch (z)
            {
                case "1":
                    {
                        Console.WriteLine("Выберите номер задания (1, 2, 3, 4):");
                        string ObjNum = Console.ReadLine();
                        switch (ObjNum)
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    zad1();
                                    break;
                                }
                            case "2":
                                {
                                    Console.Clear();
                                    zad2();
                                    break;
                                }
                            case "3":
                                {
                                    Console.Clear();
                                    zad3();
                                    break;
                                }
                            case "4":
                                {
                                    Console.Clear();
                                    zad4();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Такого номера нет!");
                                    break;
                                }

                        }
                        break;
                    }
                case "2":
                    {
                        zad22();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого номера нет!");
                        break;
                    }
            }
           

        }

        static void zad1()
        {
            int x, y, z;
            double a, b;

            Console.Write("x:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y:");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("z:");
            z = Convert.ToInt32(Console.ReadLine());

            a = (3 + Math.Pow(Math.E, 2)) / (1 + Math.Pow(x, 2) * Math.Abs(y - Math.Tan(z)));
            b = 1 + Math.Abs(y - x) + Math.Pow(y - x, 2) / 2 + Math.Pow(x - y, 2) / 3;

            Console.WriteLine("Result:");
            Console.WriteLine($"a = {a}"); Console.WriteLine($"b = {b}");
        }

        static double Dlina(int x1, int y1, int x2, int y2)
        {
            double dlina = Math.Sqrt(Math.Pow(x1 - x2,2) + Math.Pow(y1 - y2, 2));
            return dlina;
        }

        static void zad2()
        {
            int x1, y1, x2, y2, x3, y3;

            Console.WriteLine("Впишите координаты вершин треугольника:");
            Console.Write("x1: "); x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y1: "); y1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("x2: "); x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y2: "); y2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("x3: "); x3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y3: "); y3 = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            double d1 = Dlina(x1, y1, x2, y2);
            double d2 = Dlina(x2, y2, x3, y3);
            double d3 = Dlina(x1, y1, x3, y3);

            Console.WriteLine($"Длины сторон: {d1}, {d2}, {d3}");

            if ((d1 + d2) <= d3 || (d1 + d3) <= d2 || (d3 + d2) <= d1)
            { 
                Console.WriteLine("Треугольник не существует!"); return;
            }

            double p = (d2 + d2 + d3) / 2;
            double s = Math.Sqrt(p * (p - d1) * (p - d2) * (p - d3));

            Console.WriteLine($"Радиус: {s / p}");
        }

        static void zad3()
        {
            double x;

            Console.WriteLine("x: "); x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Result: {Math.Abs(5 * x - 4)}");
        }

        static void zad4()
        {
            Console.WriteLine("Впишите сезон:");
            string sezon = Console.ReadLine();

            Console.Write("\n Погода: ");
            switch(sezon.ToLower())
            {
                case "зима":
                    {
                        Console.WriteLine("очень холодно");
                        break;
                    }
                case "осень":
                    {
                        Console.WriteLine("холодно");
                        break;
                    }
                case "весна":
                    {
                        Console.WriteLine("тепло");
                        break;
                    }
                case "лето":
                    {
                        Console.WriteLine("жарко");
                        break;
                    }
                default: {
                        Console.WriteLine("Такого сезона нет!");
                        break;
                    }
            }
        }

        static void zad22()
        {
            Student Anton;
            Console.WriteLine("Введите имя студента:");
            Anton.Name = Console.ReadLine();
            Console.WriteLine("Введите возраст студента:");
            Anton.Age = Convert.ToInt32(Console.ReadLine());
            Anton.DisplayInfo();
        }
    }
}
