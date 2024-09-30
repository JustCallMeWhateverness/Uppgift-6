using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> nameList = new List<string> { "Aelin", "Dorian", "Freye", "Sam", "Eira" };

            Console.WriteLine("WELCOME TO THE LIST OF NAMES, WE HOPE YOU ENJOY YOUR STAY HERE :)");
            Console.WriteLine("\nOriginal list:");

            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }
            nameList.Sort();
            Console.WriteLine("\nSorted list:");
            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();
            if (nameList.Contains(searchName))
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
