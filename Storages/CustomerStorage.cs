class CustomerStorage
{
    private const string DataPath = @"Data/CustomerData";
    private readonly IDataStore<Customer> _dataStore;
    private readonly List<Customer> _customers = new();

    public IReadOnlyList<Customer> Customers => _customers;

    public CustomerStorage(IDataStore<Customer> dataStore) => _dataStore = dataStore;

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public void Save() => _dataStore.Save(_customers, DataPath);

    public void Load()
    {
        List<Customer>? customers = _dataStore.Load(DataPath);

        if (customers is not null) _customers.AddRange(customers);
    }
}