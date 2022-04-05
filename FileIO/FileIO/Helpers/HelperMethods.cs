using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIO.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileIO.Helpers
{
    public static class HelperMethods
    {
        public static string GetStringInputByConsole(string content)
        {
        ReEnterStringInput:
            Console.Write($"Please enter {content} : ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"--------- {content} can't be empty! --------\n" +
                                  "-------------------------------------------");
                goto ReEnterStringInput;
            }

            return input;
        }

        public static int GetIntInputByConsole(string content)
        {
        ReEnterIntInput:

            Console.Write($"Please enter {content} : ");
            string inputString = Console.ReadLine().Trim();
            int? input;

            try
            {
                input = Convert.ToInt32(inputString);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                  $"------- {content} must be digit! ------\n" +
                                  "-------------------------------------------");
                goto ReEnterIntInput;
            }

            return (int)input;
        }
    }
}
