class BikeService
{
    private readonly BikeStorage _bikeStorage;

    public BikeService(BikeStorage bikeStorage)
    {
        _bikeStorage = bikeStorage;
    }

    public bool Contains(Bike bike)
    {
        return _bikeStorage.Bikes.Any(el => el.BikeID == bike.BikeID);
    }

    public bool TryAdd(Bike bike)
    {
        if (!Contains(bike))
        {
            _bikeStorage.Add(bike);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Bike> Find(Func<Bike, bool> match)
    {
        return _bikeStorage.Bikes.Where(match).ToList();
    }
}