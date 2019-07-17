using System;
using BloodBank.Core.DataStorage;
using BloodBank.Core.Entities;

namespace BloodBank.Core.Services
{
    public class PersonService : IPersonService
    {
        private const string TableName = "Donators";

        private readonly IDataStorage _dataStorage;
        private readonly IDataProvider _dataProvider;
        public PersonService(IDataStorage dataStorage, IDataProvider dataProvider)
        {
            _dataStorage = dataStorage;
            _dataProvider = dataProvider;
        }

        public Person GetPerson(ulong id)
            => _dataProvider.GetEntity<Person>(TableName, id);

        public void AddPerson(Person person)
            => _dataStorage.Add(TableName, person);
        

        public int GetPersonCount()
            => _dataProvider.GetCount<Person>(TableName);
    }
}