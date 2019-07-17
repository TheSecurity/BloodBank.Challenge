using System.Collections.Generic;

namespace BloodBank.Core.DataStorage
{
    public interface IDataStorage
    {
        void Serialize<T>(string path, List<T> type);
        List<T> Deserialize<T>(string tableName, T type);
    }
}