class Point
{
    static void Main()
    {
        BikeService bikeService = new(new BikeStorage());

        var key = bikeService.AddOrThrow("BMX", 25, Bike.BikeType.City);  
        
    }
}