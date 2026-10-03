class RentalStorage
{
    private const string DataPath = @"Data/RentalData.json";
    private readonly IDataStore<Rental> _dataStore;
    private readonly List<Rental> _rentals = new();

    public IReadOnlyList<Rental> Rentals => _rentals;

    public RentalStorage(IDataStore<Rental> dataStore) => _dataStore = dataStore;

    public void Add(Rental rental)
    {
        _rentals.Add(rental);
    }

    public void Save() => _dataStore.Save(_rentals, DataPath);

    public void Load()
    {
        List<Rental>? rentals = _dataStore.Load(DataPath);

        if (rentals is not null) _rentals.AddRange(rentals);
    }
}