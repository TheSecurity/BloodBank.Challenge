using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Entities;

namespace BloodBank.Core.Services
{
    public class PersonPropertyValidator
    {
        public OutputObject FirstnameValidation(string input)
            => new OutputObject{Value = input};

        public OutputObject SurnameValidation(string input)
            => new OutputObject { Value = input };

        public OutputObject PersonalIdValidation(string input)
        {
            var output = new OutputObject();
            if (!ulong.TryParse(input, out var personalId))
            {
                output.ErrorMessage = "Number is invalid!";
                return output;
            }

            output.Value = personalId;
            return output;
        }

        public OutputObject DateOfBirthValidation(string input)
        {
            var output = new OutputObject();
            if (!DateTime.TryParse(input, out var datetime))
            {
                output.ErrorMessage = "Failed parsing to format dd-mm-yyyy!";
                return output;
            }

            output.Value = datetime;
            return output;
        }

        public OutputObject AddressValidation(string input)
            => new OutputObject { Value = input };

        public OutputObject CountryValidation(string input)
            => new OutputObject { Value = input };

        public OutputObject BloodTypeValidation(string input, List<BloodType> bloodTypes)
        {
            var output = new OutputObject();

            if (!int.TryParse(input, out var value) || value < 0 || value > bloodTypes.Count - 1)
            {
                output.ErrorMessage = "Invalid index inserted.";
                return output;
            }

            output.Value = new BloodInfo
            {
                BloodType = bloodTypes.ElementAt(value - 1)
            };

            return output;
        }
    }
}