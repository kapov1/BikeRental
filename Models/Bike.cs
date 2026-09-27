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
    public BikeStatus Status = BikeStatus.Available;

    public Bike(string bikeName, string bikeID, int pricePerDay, BikeType type, BikeStatus status)
    {
        BikeName = bikeName;
        BikeID = bikeID;
        PricePerDay = pricePerDay;
        Type = type;
        Status = status;
    }
}