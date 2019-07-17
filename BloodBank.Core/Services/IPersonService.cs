using BloodBank.Core.Entities;

namespace BloodBank.Core.Services
{
    public interface IPersonService
    {
        Person GetPerson(ulong id);
        void AddPerson(Person person);
        int GetPersonCount();
    }
}