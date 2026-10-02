class BikeService
{
    private readonly BikeStorage _bikeStorage;

    public BikeService(BikeStorage bikeStorage)
    {
        _bikeStorage = bikeStorage;
    }

    private bool Contains(Bike bike)
    {
        return _bikeStorage.Bikes.Any(el => el.Id == bike.Id);
    }

    private void AddToDataOrThrow(Bike bike)
    {
        if (Contains(bike)) throw new ArgumentException("A bike with the specified ID already exists.");

        _bikeStorage.Add(bike);
    }

    private Bike FindByID(Guid id)
    {
        return _bikeStorage.Bikes.First(bike => bike.Id == id);
    }

    public Guid AddOrThrow(string bikeName, int pricePerDay, Bike.BikeType bikeType)
    {
        Bike bike = new(bikeName, pricePerDay, bikeType);

        AddToDataOrThrow(bike);

        return bike.Id;
    }

    public List<BikeInfo> Find(Func<Bike, bool> match)
    {
        return _bikeStorage.Bikes
        .Where(match)
        .Select(bike => new BikeInfo(
            bike.BikeName,
            bike.PricePerDay,
            bike.Type,
            bike.Status,
            bike.Id
        ))
        .ToList();
    }

    public bool TryRent(Guid id)
    {
        var bike = FindByID(id);

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
        var bike = FindByID(id);

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
        var bike = FindByID(id);

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
}

readonly record struct BikeInfo(
    string BikeName,
    int PricePerDay,
    Bike.BikeType Type, 
    Bike.BikeStatus Status,
    Guid Id
);