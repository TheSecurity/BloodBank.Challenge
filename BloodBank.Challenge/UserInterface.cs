using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Core.Entities;
using BloodBank.Core.Services;

namespace BloodBank.ConsoleApp
{
    public class UserInterface
    {
        private readonly IPersonService _personService;
        public UserInterface(IPersonService personService)
        {
            _personService = personService;
        }

        public Task Initialize()
        {
            DrawUserInterface();
            HandleConsoleInput();

            return Task.CompletedTask;
        }

        private static void DrawUserInterface()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Blood bank!\n\n" +
                              "Please select option by its number:\n" +
                              "1. Register person\n" +
                              "2. Find person\n" +
                              "3. Person count\n" +
                              "4. Close\n\n");
        }

        private void HandleConsoleInput()
        {
            var input = Console.ReadLine();
            while (input != "4")
            {
                switch (input)
                {
                    case "1": AddPersonDialog();
                        break;
                    case "2": GetPersonDialog();
                        break;
                    case "3": _personService.GetPersonCount();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong option name!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                input = Console.ReadLine();
            }
        }

        private Task AddPersonDialog()
        {
            var person = new Person();

            Console.Write("Firstname: ");
            person.Firstname = Console.ReadLine();

            Console.Write("Surname: ");
            person.Surname = Console.ReadLine();

            Console.Write("Personal Identification Number: ");
            if (!ulong.TryParse(Console.ReadLine(), out var personalId))
            {
                Console.WriteLine("Number is invalid!");
                return Task.CompletedTask;
            }
            person.PersonalIdentificationNumber = personalId;

            Console.Write("Date of birth (dd-mm-yyyy): ");
            if(!DateTime.TryParse(Console.ReadLine(), out var datetime))
            {
                Console.WriteLine("Failed parsing to format dd-mm-yyyy");
                return Task.CompletedTask;
            }
            person.DateOfBirth = datetime;

            Console.Write("Address: ");
            person.Address = Console.ReadLine();

            Console.Write("Country: ");
            person.Country = Console.ReadLine();

            Console.Write("BloodType select option: ");
            var bloodTypes = Enum.GetValues(typeof(BloodType)).Cast<string>().ToList();
            for (var i = 0; i < bloodTypes.Count-1; i++)
            {
                Console.Write($"{i+1}. {bloodTypes[i]}");
            }

            if (!Enum.TryParse(typeof(BloodType), Console.ReadLine(), out var bloodType))
            {
                Console.WriteLine("Invalid value!");
                return Task.CompletedTask;
            }

            person.BloodInfo.BloodType = (BloodType)bloodType;

            //_personService.AddPerson(person);

            return Task.CompletedTask;
        }

        private Task GetPersonDialog()
        {

            return Task.CompletedTask;
        }
    }
}