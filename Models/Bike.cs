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
    public string BikeID { get; }
    public int PricePerDay { get; }
    public BikeType Type { get; }
    public BikeStatus Status { get; private set; } = BikeStatus.Available;

    public Bike(string bikeName, string bikeID, int pricePerDay, BikeType type)
    {
        BikeName = bikeName;
        BikeID = bikeID;
        PricePerDay = pricePerDay;
        Type = type;
    }

    public void ChangeStatusToIsService() => Status = BikeStatus.IsService;
    public void ChangeStatusToAvailable() => Status = BikeStatus.Available;
    public void ChangeStatusToRented() => Status = BikeStatus.Rented;
}