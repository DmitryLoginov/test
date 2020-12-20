﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonList people = new PersonList();

            Console.WriteLine("тест:\n");
            Console.WriteLine($"Количество элементов списка равно {people.Length()}");
            people.Print();

            people.Add("Чек", "тест", 20, Gender.Male);
            Console.WriteLine("\nтест:\n");
            Console.WriteLine($"Количество элементов списка равно {people.Length()}");
            people.Print();

            people.Add("Хочу", "жрать", 20, Gender.Male);
            people.Add("Ммм", "кфс", 20, Gender.Male);
            Console.WriteLine("\nтест:\n");
            Console.WriteLine($"Количество элементов списка равно {people.Length()}");
            people.Print();

            people.Delete(1);
            Console.WriteLine("\nтест:\n");
            Console.WriteLine($"Количество элементов списка равно {people.Length()}");
            people.Print();

            people.Erase();
            Console.WriteLine("\nтест:\n");
            people.Print();

            Console.ReadKey();
        }
    }
}
