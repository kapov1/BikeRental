interface IDataStore<T>
{
    List<T>? Load(string path);

    void Save(IEnumerable<T> data, string path);
}