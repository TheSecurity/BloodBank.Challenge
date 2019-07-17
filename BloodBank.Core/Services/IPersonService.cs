using BloodBank.Core.Entities;

namespace BloodBank.Core.Services
{
    public interface IPersonService
    {
        Person GetPerson();
        void SavePerson();
        void AddPerson();
        uint GetPersonCount();
    }
}