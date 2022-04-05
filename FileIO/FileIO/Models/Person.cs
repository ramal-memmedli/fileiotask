using FileIO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    public class Person
    {
        private static int _idCounter;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Person> People { get; set; }

        static Person()
        {
            _idCounter = WriteAndReadFileMethods.GetNewId();
        }

        public Person()
        {
            ++_idCounter;
            Id = _idCounter;
        }

        public Person(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }

        public static void CreatePersonByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                             $"------------ Create new person ------------\n" +
                              "-------------------------------------------");
            string name = HelperMethods.GetStringInputByConsole("name");
            string surname = HelperMethods.GetStringInputByConsole("surname");
            Person person = new Person(name, surname);
            WriteAndReadFileMethods.WritePersonObjectsToFile(person);
            WriteAndReadFileMethods.RemoveOldAndWriteNewIdToFile(person.Id);
        }

        public static void PrintAllPersons()
        {
            List<Person> people = WriteAndReadFileMethods.ReadPersonObjectsFromFile();

            foreach (Person person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}");
                
            }
        }
    }
}