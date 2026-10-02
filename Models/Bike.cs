class Bike
{
    public enum BikeType
    {
        City,
        Mountian,
        Road,
        Kids
    }

    public enum BikeStatus
    {
        Available,
        Rented,
        IsService
    }

    public string BikeName { get; }
    public Guid Id { get; } = Guid.NewGuid();
    public int PricePerDay { get; }
    public BikeType Type { get; }
    public BikeStatus Status { get; private set; } = BikeStatus.Available;

    public Bike(string bikeName, int pricePerDay, BikeType type)
    {
        BikeName = bikeName;
        PricePerDay = pricePerDay;
        Type = type;
    }

    public void ChangeStatusToIsService() => Status = BikeStatus.IsService;
    public void ChangeStatusToAvailable() => Status = BikeStatus.Available;
    public void ChangeStatusToRented() => Status = BikeStatus.Rented;
}