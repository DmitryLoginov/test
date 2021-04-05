﻿using System;
using System.Collections.Generic;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для формирования случайных персон.
    /// </summary>
    public static class RandomPerson
    {
        /// <summary>
        /// Строковый массив мужских имён.
        /// </summary>
        private static string[] _maleNames =
        {
            "Isaac", "Zach", "Nolan", "Hans", "Robert", "Noah",
            "Terrence", "Challus", "Michael", "Nathan", "Gabe",
            "Jacob", "Arthur", "Benjamin", "Victor", "Franco",
            "Austin", "Mark", "Dylan", "Sam", "Warren", "Colin"
        };

        /// <summary>
        /// Строковый массив женских имён.
        /// </summary>
        private static string[] _femaleNames =
        {
            "Nicole", "Kendra", "Elizabeth", "Ellie", "Lexine",
            "Daina", "Jennifer", "Karen", "Alissa", "Isabel",
            "Amelia", "Rachel", "Damara", "Catherine", "Amanda",
            "Sarah", "Donna", "Sandra", "Jessica"
        };

        /// <summary>
        /// Строковый массив фамилий.
        /// </summary>
        private static string[] _lastNames =
        {
            "Clarke", "Brennan", "Hammond", "Daniels", "Kyne",
            "Mercer", "Cross", "Temple", "Stross", "Langford",
            "Murdoch", "McNeill", "Weller", "Altman", "Carver",
            "Danik", "Delille", "Mathius", "Neumann", "Tatchet",
            "Phelps", "Santos", "Rosen", "Norton", "Caldwell",
            "Eckhardt", "Vincent", "Cooper", "Borges", "Cho",
            "Barrow", "Pawling", "Malyech", "Li", "Chang"
        };

        private static string[] _jobs =
        {
            "работа1", "работа2", "работа3"
        };

        private static string[] _learningFacilities =
        {
            "Детский сад", "Школа", "Музыкальная школа", "Художественная школа"
        };

        /// <summary>
        /// Объект класса Random.
        /// </summary>
        private static Random randNum = new Random();

        /// <summary>
        /// Возвращает случайную персону.
        /// </summary>
        /// <returns>Переменная типа Person.</returns>
        public static Person Get()
        {
            string name;
            
            Gender gender = (Gender)randNum.Next(0, 
                Enum.GetNames(typeof(Gender)).Length);
            switch (gender)
            {
                case Gender.Male:
                {
                    name = _maleNames[randNum.Next(_maleNames.Length)];
                    break;
                }
                case Gender.Female:
                {
                    name = _femaleNames[randNum.Next(_femaleNames.Length)];
                    break;
                }
                default:
                {
                    throw new Exception("Неизвестный пол.");
                }
            }
            string surname = _lastNames[randNum.Next(_lastNames.Length)];
            int age = randNum.Next(Person.MinAge, Person.MaxAge);
            
            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Возвращает случайную персону с заданным полом.
        /// </summary>
        /// <param name="gender">Пол персоны.</param>
        /// <returns>Переменная типа Person.</returns>
        public static Person Get(Gender gender)
        {
            string name;
            switch (gender)
            {
                case Gender.Male:
                    {
                        name = _maleNames[randNum.Next(_maleNames.Length)];
                        break;
                    }
                case Gender.Female:
                    {
                        name = _femaleNames[randNum.Next(_femaleNames.Length)];
                        break;
                    }
                default:
                    {
                        throw new Exception("Неизвестный пол.");
                    }
            }
            string surname = _lastNames[randNum.Next(_lastNames.Length)];
            int age = randNum.Next(Person.MinAge, Person.MaxAge);

            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Возвращает случайного взрослого (без пары).
        /// </summary>
        /// <returns>Переменная типа Adult.</returns>
        public static Adult GetSingleAdult()
        {
            string name;

            Gender gender = (Gender)randNum.Next(0,
                Enum.GetNames(typeof(Gender)).Length);
            switch (gender)
            {
                case Gender.Male:
                    {
                        name = _maleNames[randNum.Next(_maleNames.Length)];
                        break;
                    }
                case Gender.Female:
                    {
                        name = _femaleNames[randNum.Next(_femaleNames.Length)];
                        break;
                    }
                default:
                    {
                        throw new Exception("Неизвестный пол.");
                    }
            }
            string surname = _lastNames[randNum.Next(_lastNames.Length)];
            int age = randNum.Next(Adult.MinAdultAge, Person.MaxAge);
            Passport passport = Passport.GetRandomPassport();
            string job = _jobs[randNum.Next(_jobs.Length)];


            return new Adult
            (
                name, surname, age, gender,
                passport, job
            );
        }

        /// <summary>
        /// Возвращает случайного взрослого (без пары) с заданным полом.
        /// </summary>
        /// <param name="gender">Пол взрослого.</param>
        /// <returns>Переменная типа Adult.</returns>
        public static Adult GetSingleAdult(Gender gender)
        {
            string name;
            switch (gender)
            {
                case Gender.Male:
                    {
                        name = _maleNames[randNum.Next(_maleNames.Length)];
                        break;
                    }
                case Gender.Female:
                    {
                        name = _femaleNames[randNum.Next(_femaleNames.Length)];
                        break;
                    }
                default:
                    {
                        throw new Exception("Неизвестный пол.");
                    }
            }
            string surname = _lastNames[randNum.Next(_lastNames.Length)];
            int age = randNum.Next(Adult.MinAdultAge, Person.MaxAge);
            Passport passport = Passport.GetRandomPassport();
            string job = _jobs[randNum.Next(_jobs.Length)];


            return new Adult
            (
                name, surname, age, gender,
                passport, job
            );
        }

        /// <summary>
        /// Возвращает бездетную пару случайных персон.
        /// </summary>
        /// <returns>
        /// Список, состоящий из двух
        /// переменных типа Adult.
        /// </returns>
        public static List<Adult> GetChildlessAdultPair()
        {
            Adult newMale = GetSingleAdult(Gender.Male);
            Adult newFemale = GetSingleAdult(Gender.Female);

            Adult.GetMarried(newMale, newFemale);

            return new List<Adult>() { newMale, newFemale };
        }

        /// <summary>
        /// Возвращает случайного ребёнка без родителей.
        /// </summary>
        /// <returns>Переменную типа Child.</returns>
        public static Child GetChild()
        {
            string name;

            Gender gender = (Gender)randNum.Next(0,
                Enum.GetNames(typeof(Gender)).Length);
            switch (gender)
            {
                case Gender.Male:
                    {
                        name = _maleNames[randNum.Next(_maleNames.Length)];
                        break;
                    }
                case Gender.Female:
                    {
                        name = _femaleNames[randNum.Next(_femaleNames.Length)];
                        break;
                    }
                default:
                    {
                        throw new Exception("Неизвестный пол.");
                    }
            }
            string surname = _lastNames[randNum.Next(_lastNames.Length)];
            int age = randNum.Next(Person.MinAge, Child.MaxChildAge);
            string learninFacility = _learningFacilities[randNum.Next(_learningFacilities.Length)];

            return new Child
            (
                name, surname, age, gender,
                learninFacility
            );
        }

        //public static Child GetChild(Adult mother, Adult father)
        //{
        //
        //}

        /// <summary>
        /// Возвращает пару из двух женатых взрослых и ребёнка.
        /// </summary>
        /// <returns>
        /// Список типа Person, содержащий
        /// две переменные типа Adult и одну
        /// переменную типа Child.
        /// </returns>
        public static List<Person> GetPairWithAChild()
        {
            List<Adult> pair = GetChildlessAdultPair();

            Child child = GetChild();

            child.Mother = pair[1];
            child.Father = pair[0];

            pair[1].Child = child;
            pair[0].Child = child;

            return new List<Person>() { pair[1], pair[0], child };
        }
    }
}
