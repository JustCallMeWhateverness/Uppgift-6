using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uppgift_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
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

            foreach (KeyValuePair<string,int> kvp in nameList)
            {
                Console.WriteLine("Name: {0} Age: {1}", kvp.Key, kvp.Value);
            }
            var sortByName = nameList.OrderBy(kvp => kvp.Key);
            
            Console.WriteLine("\nSorted list:");
            foreach (KeyValuePair<string,int> kvp in sortByName)
            {
                Console.WriteLine("Name: {0} Age: {1} ", kvp.Key, kvp.Value);
            }

            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();
            if (nameList.ContainsKey(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }

            Console.ReadKey();

        }
    }
}
