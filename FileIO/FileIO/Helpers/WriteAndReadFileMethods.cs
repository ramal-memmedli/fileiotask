using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FileIO.Models;

namespace FileIO.Helpers
{
    public static class WriteAndReadFileMethods
    {
        public static int GetNewId()
        {
            string dataDirectory = Path.Combine(Constants.rootDir, "Context");
            string dataFile = Path.Combine(dataDirectory, "id.txt");

            int newId = 0;

            using(StreamReader sr = new StreamReader(dataFile))
            {
                newId = Convert.ToInt32(sr.ReadLine());
            }
            return newId;
        }

        public static void RemoveOldAndWriteNewIdToFile(int? id)
        {
            string dataDirectory = Path.Combine(Constants.rootDir, "Context");

            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            string dataFile = Path.Combine(dataDirectory, "id.txt");

            if (!File.Exists(dataFile))
            {
                File.Create(dataFile);
            }

            using (StreamWriter sw = new StreamWriter(dataFile))
            {
                sw.WriteLine(id);
            }
        }

        public static void Write(string directory, string data)
        {
            string dataDirectory = Path.Combine(directory, "Context");

            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            string dataFile = Path.Combine(dataDirectory, "persons.txt");

            if (!File.Exists(dataFile))
            {
                File.Create(dataFile);
            }

            using (StreamWriter sw = new StreamWriter(dataFile, true))
            {
                sw.WriteLine(data);
            }
        }

        public static void WritePersonObjectsToFile(Person person)
        {
            string personSerialized = JsonSerializer.Serialize(person);

            Write(Constants.rootDir, personSerialized);
        }

        public static List<Person> ReadPersonObjectsFromFile()
        {
            string dataDirectory = Path.Combine(Constants.rootDir, "Context");
            string dataFile = Path.Combine(dataDirectory, "persons.txt");

            List<string> jsonList = new List<string>();

            List<Person> people = new List<Person>();

            using (StreamReader sr = new StreamReader(dataFile))
            {
                string jsonString;
                while ((jsonString = sr.ReadLine()) != null)
                {
                    jsonList.Add(jsonString);
                }
            }

            foreach (var item in jsonList)
            {
                people.Add(JsonSerializer.Deserialize<Person>(item));
            }
            return people;
        }
    }
}
