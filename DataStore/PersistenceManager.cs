class PersistenceManager
{
    private readonly BikeStorage _bikeStorage;
    private readonly CustomerStorage _customerStorage;
    private readonly RentalStorage _rentalStorage;

    public PersistenceManager(BikeStorage bikeStorage, CustomerStorage customerStorage, RentalStorage rentalStorage)
    {
        _bikeStorage = bikeStorage;
        _customerStorage = customerStorage;
        _rentalStorage = rentalStorage;
    }

    public void LoadData()
    {
        _bikeStorage.Load();
        _customerStorage.Load();
        _rentalStorage.Load();
    }

    public void SaveData()
    {
        _bikeStorage.Save();
        _customerStorage.Save();
        _rentalStorage.Save();
    }
}