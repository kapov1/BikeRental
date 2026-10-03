class Bike
{
    public enum BikeType
    {
        City,
        Mountain,
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
    public Guid Id { get; }
    public int PricePerDay { get; }
    public BikeType Type { get; }
    public BikeStatus Status { get; private set; }

    public Bike(string bikeName, int pricePerDay, BikeType type, Guid id, BikeStatus status = BikeStatus.Available)
    {
        BikeName = bikeName;
        PricePerDay = pricePerDay;
        Type = type;
        Id = id;
        Status = status;
    }

    public void ChangeStatusToIsService() => Status = BikeStatus.IsService;
    public void ChangeStatusToAvailable() => Status = BikeStatus.Available;
    public void ChangeStatusToRented() => Status = BikeStatus.Rented;
}