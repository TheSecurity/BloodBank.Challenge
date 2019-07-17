using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.DataStorage;
using LiteDB;

namespace BloodBank.Storage
{
    public class Storage : IDataStorage
    {
        public void Serialize<T>(string tableName, List<T> objects)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                var data =  database.GetCollection<T>(tableName);
                var validData = objects.Except(data.FindAll().ToList());
                data.InsertBulk(validData);
            }
        }

        public List<T> Deserialize<T>(string tableName, T objects)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                return database.GetCollection<T>(tableName).FindAll().ToList();
            }
        }
    }
}
