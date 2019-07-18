using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Core.Entities;
using BloodBank.Core.Services;
using Console = System.Console;

namespace BloodBank.ConsoleApp
{
    public class UserInterface
    {
        private readonly IPersonService _personService;
        private readonly PersonPropertyValidator _propertyValidator;
        public UserInterface(IPersonService personService, PersonPropertyValidator propertyValidator)
        {
            _personService = personService;
            _propertyValidator = propertyValidator;
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
            Console.WriteLine("\n\n\n=====================================\n" +
                              "Welcome to Blood bank!\n\n" +
                              "Please select option by its number:\n" +
                              "1. Register person\n" +
                              "2. Find person\n" +
                              "3. Person count\n" +
                              "4. Close\n\n" +
                              "=====================================\n");
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
                        DrawUserInterface();
                        break;
                }
                input = Console.ReadLine();
            }
        }

        private void AddPersonDialog()
        {
            var person = new Person();

            Console.WriteLine("===== REGISTER NEW PERSON =====");

            Console.Write("Firstname: ");
            var firstName = _propertyValidator.FirstnameValidation(Console.ReadLine());
            if (firstName.ErrorMessage != null)
            {
                ErrorOccured(firstName.ErrorMessage);
                return;
            }
            person.Firstname = firstName.Value.ToString();

            Console.Write("Surname: ");
            var surname = _propertyValidator.SurnameValidation(Console.ReadLine());
            if (firstName.ErrorMessage != null)
            {
                ErrorOccured(surname.ErrorMessage);
                return;
            }
            person.Surname = surname.Value.ToString();

            Console.Write("Personal Identification Number: ");
            var personalId = _propertyValidator.PersonalIdValidation(Console.ReadLine());
            if (personalId.ErrorMessage != null)
            {
                ErrorOccured(surname.ErrorMessage);
                return;
            }
            person.PersonalIdentificationNumber = (ulong)personalId.Value;

            Console.Write("Date of birth (dd-mm-yyyy): ");
            var dateOfBirth = _propertyValidator.DateOfBirthValidation(Console.ReadLine());
            if (dateOfBirth.ErrorMessage != null)
            {
                ErrorOccured(dateOfBirth.ErrorMessage);
                return;
            }
            person.DateOfBirth = (DateTime)dateOfBirth.Value;

            Console.Write("Address: ");
            var address = _propertyValidator.AddressValidation(Console.ReadLine());
            if (address.ErrorMessage != null)
            {
                ErrorOccured(address.ErrorMessage);
                return;
            }
            person.Address = address.Value.ToString();

            Console.Write("Country: ");
            var country = _propertyValidator.CountryValidation(Console.ReadLine());
            if (country.ErrorMessage != null)
            {
                ErrorOccured(country.ErrorMessage);
                return;
            }
            person.Country = (string)country.Value;

            Console.WriteLine("Blood types select option: ");
            var bloodTypes = Enum.GetValues(typeof(BloodType)).Cast<BloodType>().ToList();
            for (var i = 0; i < bloodTypes.Count - 1; i++)
            {
                Console.Write($"{i + 1}. {bloodTypes[i]}\n");
            }
            var bloodType = _propertyValidator.BloodTypeValidation(Console.ReadLine(), bloodTypes);
            if (bloodType.ErrorMessage != null)
            {
                ErrorOccured(bloodType.ErrorMessage);
                return;
            }
            person.BloodInfo = (BloodInfo)bloodType.Value;
            
            _personService.AddPerson(person, person.PersonalIdentificationNumber);
        }

        private void GetPersonDialog()
        {
            Console.WriteLine("\n\n===== GET PERSON =====");

            Console.Write("Personal Identification Number: ");

            if (!ulong.TryParse(Console.ReadLine(), out var result))
            {
                ErrorOccured("Invalid number inserted.");
                return;
            }

            var person = _personService.GetPerson(result);

            Console.WriteLine("\n\n==== Personal Details ====\n" +
                              $"Firstname: {person.Firstname}\n" +
                              $"Surname: {person.Surname}\n" +
                              $"Personal Identification Number: {person.PersonalIdentificationNumber}\n" +
                              $"Date of birth: {person.DateOfBirth.ToString(CultureInfo.InvariantCulture)}\n" +
                              $"Address: {person.Address}\n" +
                              $"Country: {person.Country}\n" +
                              $"Blood type: {person.BloodInfo.BloodType}");
        }

        private static void ErrorOccured(string text)
        {
            Console.WriteLine(text);
            DrawUserInterface();
        }
    }
}