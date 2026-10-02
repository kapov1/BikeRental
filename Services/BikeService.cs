class BikeService
{
    private readonly BikeStorage _bikeStorage;

    public BikeService(BikeStorage bikeStorage)
    {
        _bikeStorage = bikeStorage;
    }

    private void AddToDataOrThrow(Bike bike) => _bikeStorage.Add(bike);

    private Bike FindByIDOrThrow(Guid id)
    {
        return _bikeStorage.Bikes.First(bike => bike.Id == id);
    }

    public Guid AddOrThrow(string bikeName, int pricePerDay, Bike.BikeType bikeType)
    {
        Bike bike = new(bikeName, pricePerDay, bikeType);

        AddToDataOrThrow(bike);

        return bike.Id;
    }

    public bool TryRent(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status == Bike.BikeStatus.Available)
        {
            bike.ChangeStatusToRented();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryReturn(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status != Bike.BikeStatus.Available)
        {
            bike.ChangeStatusToAvailable();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySendToMaintenance(Guid id)
    {
        var bike = FindByIDOrThrow(id);

        if (bike.Status == Bike.BikeStatus.Available)
        {
            bike.ChangeStatusToIsService();
            return true;
        }
        else
        {
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