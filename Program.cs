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
    //Lagt till Console.Clear för att simulera nytt fönster när användaren väljer ett alternativ i menyn för att göra programmet mer tydligt & användarvänligt
    class Program
    {
        //Kontroll för imatning av ålder kan nu användas på flera ställen i koden utan upprepning av kod
        public static int ValidAge(Dictionary<string, int> myDictionary)
        {
            int age = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter age:");
                    age = int.Parse(Console.ReadLine());
                    //Om inmatningen är korrekt lämnar den loop
                    if (age >= 0)
                    {
                        break;
                    }
                    //Fångar upp om inmatningen är ett negativt tal
                    else
                    {
                        Console.WriteLine("Age can't be negative. Enter a valid number");
                    }
                }
                //Fångar upp om inmatningen ej är ett nummer
                catch (FormatException)
                {
                    Console.WriteLine("Age must be a number. Enter a valid number");
                }
            }
            return age;

        }
        //Kontroll av inmatning av namn kan nu användas på flera ställen i koden utan upprepning av kod
        public static string ValidName(Dictionary<string, int> myDictionary)
        {
            string name = "";
            while (true)
            {
                Console.WriteLine("Enter name:");
                name = Console.ReadLine();

                //Fångar upp om inmatningen är tom
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Enter a valid name");
                }
                //Fångar upp om användaren skriver in ett nummer
                else if (int.TryParse(name, out _))
                {
                    Console.WriteLine("Names can't be numbers. Enter a valid name");
                }
                else
                {
                    break;
                }
            }
            return name;
        }
        //Användaren kan lägga till ny person
        public static void AddPerson(Dictionary<string, int> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("\nAdd a new person");

            string name = ValidName(myDictionary);

            int age = ValidAge(myDictionary);
            myDictionary.Add(name, age);
            Console.WriteLine($"Name: {name} with Age: {age} has now been added");

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        //Skriver ut den nuvarande listan
        public static void ShowAllPeople(Dictionary<string, int> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("\nThe people currently existing here:");
            foreach (KeyValuePair<string, int> kvp in myDictionary)
            {
                Console.WriteLine("Name: {0} Age: {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        //Användaren kan uppdatera en persons ålder
        public static void UpdatePersonAge(Dictionary<string, int> myDictionary)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nWhat is the name of the person you wanna change the age of?");
                string name = ValidName(myDictionary);
                //Kontrollerar om namnet finns
                if (myDictionary.ContainsKey(name))
                {

                    Console.WriteLine($"\nThe current age for {name} is {myDictionary[name]}");
                    Console.WriteLine($"What age should {name} have instead?");
                    int age = ValidAge(myDictionary);
                    Console.WriteLine($"The age of {name} has now been changed to {age}");
                    myDictionary[name] = age;
                    break;
                }
                //Fångar upp om namnet inte finns
                else
                {
                    Console.WriteLine("Sorry! That name does not exist here!Try again");
                    Console.WriteLine("\nThe people currently existing here:");
                    foreach (KeyValuePair<string, int> kvp in myDictionary)
                    {
                        Console.WriteLine("Name: {0}", kvp.Key);
                    }
                }
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();

        }
        //Sorterar personerna i alfabetiskt order
        public static void SortPeople(Dictionary<string, int> myDictionary)
        {
            Console.Clear();
            var sortByName = myDictionary.OrderBy(kvp => kvp.Key);

            Console.WriteLine("\nThe people are now sorted in alphabetical order:");
            //Skriver ut alla namn och deras ålder med en forach loop i alfabetisk order
            foreach (KeyValuePair<string, int> kvp in sortByName)
            {
                Console.WriteLine("Name: {0} Age: {1} ", kvp.Key, kvp.Value);
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        //Användaren kan söka efter en person
        public static void SearchPerson(Dictionary<string, int> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("\nWho do you wanna search for?");
            string searchName = ValidName(myDictionary);
            //Personen finns med
            if (myDictionary.ContainsKey(searchName))
            {
                Console.WriteLine($"A person with that name exist here! Name: {searchName} Age: {myDictionary[searchName]}");
            }
            //Personen finns inte med
            else
            {
                Console.WriteLine($"Sorry! {searchName} does not exist here! Maybe you should add them to this world :)");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
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
            int menu = 0;
            Console.WriteLine("WELCOME TO THE WORLD OF NAMES, WE HOPE YOU ENJOY YOUR STAY HERE :)");
            Console.WriteLine("\nThe original people that exist here:");
            //Skriver ut alla namn & deras ålder med en foreach loop
            foreach (KeyValuePair<string, int> kvp in nameList)
            {
                Console.WriteLine("Name: {0} Age: {1}", kvp.Key, kvp.Value);
            }

            //skapar en switch meny med 6 olika alternativ
            do
            {
                Console.WriteLine("\nWhat do you want to do with this world? Choose an option from 1-6");
                Console.WriteLine("1:Add person");
                Console.WriteLine("2:Show all people");
                Console.WriteLine("3:Update existing persons age");
                Console.WriteLine("4:Sort people in alphabetical order");
                Console.WriteLine("5:Search for a person");
                Console.WriteLine("6:Exit");

                string input = Console.ReadLine();
                bool validInput = int.TryParse(input, out menu);
                //Fångar upp om användarens inmatning är felaktig
                if (!validInput || menu < 1 || menu > 6)
                {
                    Console.WriteLine("Invalid input.Try again!");
                    menu = -1;
                    continue;
                }

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
                    default:
                        Console.WriteLine("Invalid input.Try again!");
                        break;
                }
            } while (menu != 0);
            Console.Clear();
            Console.WriteLine("Goodbye for now! Have a great day :)");
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }
    }
}