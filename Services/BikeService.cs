using Microsoft.Extensions.Logging;

class BikeService
{
    private readonly BikeStorage _bikeStorage;
    private readonly ILogger<BikeService> _logger;

    public BikeService(BikeStorage bikeStorage, ILogger<BikeService> logger)
    {
        _bikeStorage = bikeStorage;
        _logger = logger;
    }

    private void AddToData(Bike bike)
    {
        _bikeStorage.Add(bike);
        _logger.LogInformation("Bike added to storage.\nBike: {BikeId}", bike.Id);
    }

    private Bike FindByIDOrThrow(Guid id)
    {
        return _bikeStorage.Bikes.First(bike => bike.Id == id);
    }

    public Guid Add(string bikeName, int pricePerDay, Bike.BikeType bikeType)
    {
        Bike bike = new(bikeName, pricePerDay, bikeType, Guid.NewGuid());

        AddToData(bike);

        _logger.LogInformation("Bike added successfully.\nBike: {BikeId}", bike.Id);

        return bike.Id;
    }

    public bool TryRent(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status == Bike.BikeStatus.Available)
        {
            bike.ChangeStatusToRented();
            _logger.LogInformation("Bike rented.\nBike: {BikeId}", id);
            return true;
        }
        else
        {
            _logger.LogWarning("Failed to rent bike.\nBike: {BikeId}", id);
            return false;
        }
    }

    public bool TryReturn(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status == Bike.BikeStatus.Rented)
        {
            bike.ChangeStatusToAvailable();
            _logger.LogInformation("Bike returned.\nBike: {BikeId}", id);
            return true;
        }
        else
        {
            _logger.LogWarning("Failed to return bike,\nBike: {BikeId}", id);
            return false;
        }
    }

    public bool TrySendToMaintenance(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status == Bike.BikeStatus.Available)
        {
            bike.ChangeStatusToIsService();
            _logger.LogInformation("Bike sent for maintenance.\nBike: {BikeId}", id);
            return true;
        }
        else
        {
            _logger.LogWarning("Failed to send bike for maintenance.\nBike: {BikeId}", id);
            return false;
        }
    }

    public bool TryReturnFromMaintenance(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status == Bike.BikeStatus.IsService)
        {
            bike.ChangeStatusToAvailable();
            _logger.LogInformation("Bike returned from maintenance.\nBike: {BikeId}", id);
            return true;
        }
        else
        {
            _logger.LogWarning("Failed to return bike from maintenance.\nBike: {BikeId}", id);
            return false;
        }

    }

    public BikeInfo GetRequiredBikeInfo(Guid id)
    {
        var bike = _bikeStorage.Bikes.FirstOrDefault(bike => bike.Id == id);

        if (bike is null) throw new KeyNotFoundException("Bike with the specified key was not found.");

        return new(bike.BikeName, bike.PricePerDay, bike.Type, bike.Id);
    }

    public Bike.BikeStatus GetRequiredBikeStatus(Guid id)
    {
        var bike = FindByIDOrThrow(id);
        return bike.Status;
    }
}