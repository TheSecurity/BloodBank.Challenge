using BloodBank.Core.DataStorage;
using LiteDB;

namespace BloodBank.Storage
{
    public class DataStorage : IDataStorage
    {
        public void Add<T>(string tableName, T data)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                var collection = database.GetCollection<T>(tableName);
                collection.Insert(data);
            }
        }

        public void Remove<T>(string tableName, ulong id)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                var collection = database.GetCollection<T>(tableName);
                collection.Delete(tableName);
            }
        }

        public void Update<T>(string tableName, T data)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                var collection = database.GetCollection<T>(tableName);
                collection.Update(data);
            }
        }
    }
}
