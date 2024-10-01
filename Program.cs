using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uppgift_6
{
    class Program
    {
        //Användaren kan lägga till ny person
        public static void AddPerson(Dictionary<string, int> myDictionary)
        {
            Console.WriteLine("\nAdd a new person");
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            myDictionary.Add(name, age);
        }
        //Skriver ut den nuvarande listan
        public static void ShowAllPeople(Dictionary<string, int> myDictionary)
        {

            Console.WriteLine("Current list:");
            foreach (KeyValuePair<string, int> kvp in myDictionary)
            {
                Console.WriteLine("Name: {0} Age: {1}", kvp.Key, kvp.Value);
            }

        }
        //Användaren kan uppdatera en persons ålder
        public static void UpdatePersonAge(Dictionary<string, int> myDictionary)
        {
            Console.WriteLine("Enter the persons name you wanna change the age of");
            string name = Console.ReadLine();
            Console.WriteLine($"Enter the new age for {name}");
            int age = int.Parse(Console.ReadLine());

            if (myDictionary.ContainsKey(name))
            {
                myDictionary[name] = age;

            }

        }
        //Sorterar personerna i alfabetiskt order
        public static void SortPeople(Dictionary<string, int> myDictionary)
        {

            var sortByName = myDictionary.OrderBy(kvp => kvp.Key);

            Console.WriteLine("\nSorted list:");
            //Skriver ut alla namn och deras ålder med en forach loop i alfabetisk order
            foreach (KeyValuePair<string, int> kvp in sortByName)
            {
                Console.WriteLine("Name: {0} Age: {1} ", kvp.Key, kvp.Value);
            }


        }
        //Användaren kan söka efter en person
        public static void SearchPerson(Dictionary<string, int> myDictionary)
        {
            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();
            //Personen finns med
            if (myDictionary.ContainsKey(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            //Personen finns inte med
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }
        }

        static void Main(string[] args)
        {
            //Skapar Dictionary
            Dictionary<string, int> nameList = new Dictionary<string, int>
            {
                {"Aelin",23},
                {"Dorian",25},
                {"Freye",32},
                {"Sam",18},
                {"Eira",12}
            };
            int menu;
            Console.WriteLine("WELCOME TO THE LIST OF NAMES, WE HOPE YOU ENJOY YOUR STAY HERE :)");
            Console.WriteLine("\nOriginal list:");
            //Skriver ut alla namn & deras ålder med en foreach loop
            foreach (KeyValuePair<string, int> kvp in nameList)
            {
                Console.WriteLine("Name: {0} Age: {1}", kvp.Key, kvp.Value);
            }

            //skapar en meny med 6 olika alternativ så användaren själv kan välja vad den vill göra
            do
            {
                Console.WriteLine("\nChoose one of the options below");
                Console.WriteLine("1:Add person");
                Console.WriteLine("2:Show all people");
                Console.WriteLine("3:Update existing persons age");
                Console.WriteLine("4:Sort people in alphabetical order");
                Console.WriteLine("5:Search for a person");
                Console.WriteLine("6:Exit");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        AddPerson(nameList);
                        break;
                    case 2:
                        ShowAllPeople(nameList);
                        break;
                    case 3:
                        UpdatePersonAge(nameList);
                        break;
                    case 4:
                        SortPeople(nameList);
                        break;
                    case 5:
                        SearchPerson(nameList);
                        break;
                    case 6:
                        menu = 0;
                        break;

                }

            } while (menu != 0);

            Console.ReadKey();

        }
    }
}

