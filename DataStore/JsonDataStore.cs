using System.Text.Json;

class JsonDataStore<T> : IDataStore<T>
{
    public List<T>? Load(string path)
    {
        string text = File.ReadAllText(path);

        return JsonSerializer.Deserialize<List<T>>(text);
    }

    public void Save(IEnumerable<T> data, string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(data, options);

        File.WriteAllText(path, json);
    }
}