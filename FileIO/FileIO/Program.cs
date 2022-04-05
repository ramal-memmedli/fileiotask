using System;
using System.IO;
using FileIO.Helpers;
using FileIO.Models;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
        Menu:

            Console.WriteLine("-------------------------------------------\n" +
                              "" +
                              "1 - Create new person\n" +
                              "2 - Print all persons\n" +
                              "0 - Save and exit\n" +
                              "" +
                              "-------------------------------------------");

            int input = HelperMethods.GetIntInputByConsole("input");

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Person.CreatePersonByConsole();
                    goto Menu;
                case 2:
                    Console.Clear();
                    Person.PrintAllPersons();
                    goto Menu;
                case 0:
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    goto Menu;
            }
        }
    }
}
