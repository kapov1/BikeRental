class BikeStorage
{
    private const string DataPath = @"Data/BikeData.json";
    private readonly IDataStore<Bike> _dataStore;
    private readonly List<Bike> _bikes = new();

    public IReadOnlyList<Bike> Bikes => _bikes;

    public BikeStorage(IDataStore<Bike> dataStore) => _dataStore = dataStore;

    public void Add(Bike bike)
    {
        _bikes.Add(bike);
    }

    public void Save() => _dataStore.Save(_bikes, DataPath);

    public void Load()
    {
        List<Bike>? bikes = _dataStore.Load(DataPath);

        if (bikes is not null) _bikes.AddRange(bikes);
    }
}