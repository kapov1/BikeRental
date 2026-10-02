readonly record struct BikeInfo(
    string BikeName,
    int PricePerDay,
    Bike.BikeType Type, 
    Guid Id
);