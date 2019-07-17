using System;
using System.Threading.Tasks;
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
                    case "1":
                        _personService.AddPerson();
                        break;
                    case "2":
                        _personService.GetPerson();
                        break;
                    case "3":
                        _personService.GetPersonCount();
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
    }
}