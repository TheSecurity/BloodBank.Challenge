using BloodBank.Core.Entities;

namespace BloodBank.Core.Services
{
    public interface IPersonService
    {
        void AddPerson();
        Person GetPerson();
        uint GetPersonCount();
    }
}