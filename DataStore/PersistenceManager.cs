using Microsoft.Extensions.Logging;

class PersistenceManager
{
    private readonly BikeStorage _bikeStorage;
    private readonly CustomerStorage _customerStorage;
    private readonly RentalStorage _rentalStorage;
    private readonly ILogger<PersistenceManager> _logger;

    public PersistenceManager(BikeStorage bikeStorage, CustomerStorage customerStorage, RentalStorage rentalStorage, ILogger<PersistenceManager> logger)
    {
        _bikeStorage = bikeStorage;
        _customerStorage = customerStorage;
        _rentalStorage = rentalStorage;
        _logger = logger;
    }

    public void LoadData()
    {
        _logger.LogInformation("Data loading started");
        _bikeStorage.Load();
        _customerStorage.Load();
        _rentalStorage.Load();
        _logger.LogInformation("Data loading completed");
    }

    public void SaveData()
    {
        _logger.LogInformation("Data saving started");
        _bikeStorage.Save();
        _customerStorage.Save();
        _rentalStorage.Save();
        _logger.LogInformation("Data saving completed");
    }
}