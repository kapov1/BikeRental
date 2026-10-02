readonly record struct BikeInfo(
    string BikeName,
    int PricePerDay,
    Bike.BikeType Type, 
    Bike.BikeStatus Status,
    Guid Id
);