using BloodBank.Core.DataStorage;
using LiteDB;

namespace BloodBank.Storage
{
    public class DataProvider : IDataProvider
    {
        public T GetEntity<T>(string tableName, ulong id)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                var data = database.GetCollection<T>(tableName);
                return data.FindById(id);
            }
        }

        public int GetCount<T>(string tableName)
        {
            using (var database = new LiteDatabase("@BloodBank.db"))
            {
                var data = database.GetCollection<T>(tableName);
                return data.Count();
            }
        }
    }
}