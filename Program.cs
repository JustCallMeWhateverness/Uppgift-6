using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uppgift_6
{
    class Program
    {
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
            
            Console.WriteLine("WELCOME TO THE LIST OF NAMES, WE HOPE YOU ENJOY YOUR STAY HERE :)");
            Console.WriteLine("\nOriginal list:");
            //Skriver ut alla namn & deras ålder med en foreach loop
            foreach (KeyValuePair<string,int> kvp in nameList)
            {
                Console.WriteLine("Name: {0} Age: {1}", kvp.Key, kvp.Value);
            }
            //Användaren kan lägga till en ny person
            Console.WriteLine("\nAdd a new person");
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            nameList.Add(name, age);

            //Sorterar alfabetiskt
            var sortByName = nameList.OrderBy(kvp => kvp.Key);

            Console.WriteLine("\nSorted list:");
            //Skriver ut alla namn och deras ålder med en forach loop i alfabetisk order
            foreach (KeyValuePair<string,int> kvp in sortByName)
            {
                Console.WriteLine("Name: {0} Age: {1} ", kvp.Key, kvp.Value);
            }
            //Användaren kan söka efter en person med ett specifikt namn
            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();
            //Personen finns med
            if (nameList.ContainsKey(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            //Personen finns inte med
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }

            Console.ReadKey();

        }
    }
}
