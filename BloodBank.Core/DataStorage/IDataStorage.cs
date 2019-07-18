namespace BloodBank.Core.DataStorage
{
    public interface IDataStorage
    {
        void Add<T>(string tableName, T data, ulong id);
        void Remove<T>(string tableName, ulong id);
        void Update<T>(string tableName, T data);
    }
}