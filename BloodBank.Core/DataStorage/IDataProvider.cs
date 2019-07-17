using System.Globalization;

namespace BloodBank.Core.DataStorage
{
    public interface IDataProvider
    {
        T GetEntity<T>(string tableName, ulong id);
        int GetCount<T>(string tableName);
    }
}