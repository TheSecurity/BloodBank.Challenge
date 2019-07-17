using System;

namespace BloodBank.Core.Entities
{
    public class Person
    {
        public ulong PersonalIdentificationNumber { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public BloodInfo BloodInfo { get; set; }
    }
}