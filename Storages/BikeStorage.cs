class BikeStorage
{
    private readonly List<Bike> _bikes = new();

    public IReadOnlyList<Bike> Bikes => _bikes;

    public void Add(Bike bike)
    {
        _bikes.Add(bike);
    }
}